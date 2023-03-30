using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class BalanceGaugeManager : MonoBehaviour
    {
        [field:SerializeField] public Transform Cursor { get; private set; }
        
        [SerializeField] private GameObject _balanceGaugeUI;
        [SerializeField] private float _cursorAngleMultiplier = 4;
        [SerializeField] private GameObject _lT, _rT;
        [SerializeField] private Image _gaugeLeft, _gaugeRight;

        private float _currentAngle;

        public void SetBalanceGaugeActive(bool isActive)
        {
            _balanceGaugeUI.SetActive(isActive);
        }

        public void SetBalanceCursor(float angle)
        {
            angle *= _cursorAngleMultiplier;
            Vector3 rotation = Cursor.transform.rotation.eulerAngles;
            _currentAngle = Mathf.Lerp(_currentAngle, angle, 0.1f);
            Cursor.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, _currentAngle);
        }

        public void MakeCursorFeedback()
        {
            Cursor.DOComplete();
            Cursor.DOPunchScale(Vector3.one * 0.025f, 0.15f);
        }

        public void ShowTrigger(bool showLT, bool showRT)
        {
            _lT.SetActive(showLT);
            _rT.SetActive(showRT);
        }

        public void ReduceGauge(float timer)
        {
            _gaugeLeft.fillAmount = 0.25f- timer;
            _gaugeRight.fillAmount = 0.25f - timer;
        }
        public void ResetGauge()
        {
            _gaugeLeft.fillAmount = 0.25f;
            _gaugeRight.fillAmount = 0.25f;
        }

        public float PercentGauge()
        {
            return _gaugeLeft.fillAmount / .25f;
        }

    }
}
