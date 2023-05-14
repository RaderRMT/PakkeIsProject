using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using Character.Camera;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.WeaponWheel
{
    public class WeaponUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _weaponUI;
        [SerializeField] private Transform _vignette;

        [SerializeField] private List<WheelButton> Buttons;

        [SerializeField] private Image _paddleArrowDownImage;
        [SerializeField] private Image _cursor;
        [SerializeField] private Transform _cursorPivot;
        [SerializeField] private Image _cooldown;
        [SerializeField] private float _pressTimeToOpenMenu;

        [field: SerializeField, Header("AutoAim")]
        public AutoAimUIController AutoAimController { get; private set; }

        [Header("Events")] public UnityEvent OnWheelOpened;
        public UnityEvent OnWheelClosed;
        public UnityEvent OnWheelSelectionChanged;

        private Vector3 _vignetteBaseScale;
        private bool _isMenuOpen;

        private InputManagement _inputManagement;
        private CharacterManager _characterManager;
        private CameraManager _cameraManager;

        private float _currentPressTime;
        private WeaponWheelButtonController _lastSelectedButton, _lastWeaponButtonSelected, _lastButtonCursorWasOn;

        private void Start()
        {
            _characterManager = CharacterManager.Instance;
            _inputManagement = _characterManager.InputManagementProperty;
            _cameraManager = _characterManager.CameraManagerProperty;

            _vignetteBaseScale = _vignette.localScale;
            _weaponUI.SetActive(_isMenuOpen);

            SetCursor(false);
            SetCooldownUI(0);
            SetPaddleDownImage(false);

            _lastWeaponButtonSelected = Buttons.OrderBy(x => x.ButtonController.IsPaddle).FirstOrDefault().ButtonController;
            _lastSelectedButton = Buttons.Find(x => x.ButtonController.IsPaddle).ButtonController;
            _lastButtonCursorWasOn = _lastWeaponButtonSelected;
        }

        private void Update()
        {
            if (_characterManager.CurrentStateBaseProperty.CanCharacterOpenWeapons == false)
            {
                return;
            }

            //menu is open
            if (_isMenuOpen)
            {
                WeaponChoice();
                if (_inputManagement.Inputs.OpenWeaponMenu == false)
                {
                    PressMenu();
                }

                _currentPressTime = 0;
                return;
            }

            //menu is closed && open menu touch is pressed
            if (_inputManagement.Inputs.OpenWeaponMenu)
            {
                _currentPressTime += Time.deltaTime;
                if (_currentPressTime > _pressTimeToOpenMenu)
                {
                    PressMenu();
                }

                return;
            }

            //menu is closed && open menu touch isn't pressed anymore
            if (_inputManagement.Inputs.OpenWeaponMenu == false && _currentPressTime > 0f)
            {
                FastWeaponChange();
                _currentPressTime = 0;
            }
        }

        private void FastWeaponChange()
        {
            if (_lastSelectedButton.IsPaddle)
            {
                _lastWeaponButtonSelected.Select();
                _lastSelectedButton = _lastWeaponButtonSelected;
            }
            else
            {
                foreach (WheelButton button in Buttons)
                {
                    if (button.ButtonController.IsPaddle == false)
                    {
                        continue;
                    }
                    _lastSelectedButton = button.ButtonController;
                }
                CharacterManager.Instance.CurrentStateBaseProperty.LaunchNavigationState();
            }
        }

        private void PressMenu()
        {
            _characterManager.CurrentStateBaseProperty.CanCharacterMove = _isMenuOpen;
            _characterManager.CurrentStateBaseProperty.CanCharacterMakeActions = _isMenuOpen;
            _cameraManager.CanMoveCameraManually = _isMenuOpen;

            if (_isMenuOpen && EventSystem.current.currentSelectedGameObject != null)
            {
                WeaponWheelButtonController button = EventSystem.current.currentSelectedGameObject.GetComponent<WeaponWheelButtonController>();
                if (button != null)
                {
                    _lastSelectedButton = button;
                    if (button.IsPaddle)
                    {
                        goto IfEnd;
                    }
                    button.Select();
                    _lastWeaponButtonSelected = button;
                }
            }

            IfEnd:

            _isMenuOpen = _isMenuOpen == false;
            ResetSelection();

            _weaponUI.SetActive(_isMenuOpen);
            CharacterManager.Instance.ExperienceManagerProperty.ExperienceUIManagerProperty.SetActive(_isMenuOpen);

            if (_isMenuOpen)
            {
                VignetteZoom();
                OnWheelOpened.Invoke();
                return;
            }
            OnWheelClosed.Invoke();
        }

        private void WeaponChoice()
        {
            //angle
            const float DEADZONE = 0.25f;
            float angleRad = Mathf.Atan2(_inputManagement.Inputs.SelectWeaponMenu.y,
                _inputManagement.Inputs.SelectWeaponMenu.x);
            float angleDeg = angleRad * Mathf.Rad2Deg - 90;
            if (angleDeg < 0)
            {
                angleDeg += 360f;
            }

            if (_inputManagement.Inputs.SelectWeaponMenu.magnitude <= DEADZONE)
            {
                return;
            }

            //button choice
            for (int i = 0; i < Buttons.Count; i++)
            {
                WheelButton button = Buttons[i];
                if (angleDeg < button.Angle.y && angleDeg >= button.Angle.x)
                {
                    WeaponWheelButtonController controller = button.ButtonController;
                    if (controller != _lastButtonCursorWasOn)
                    {
                        OnWheelSelectionChanged.Invoke();
                    }
                    _lastButtonCursorWasOn = controller;
                    controller.Hover();
                    continue;
                }

                button.ButtonController.Exit();
            }

            //cursor
            Vector3 rotation = _cursorPivot.rotation.eulerAngles;
            _cursorPivot.rotation = Quaternion.Euler(new Vector3(rotation.x, rotation.y, angleDeg));
        }

        public void ResetSelection()
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        private void VignetteZoom()
        {
            _vignette.localScale = _vignetteBaseScale * 2;
            _vignette.DOScale(_vignetteBaseScale, 0.3f);
        }

        #region Set images

        public void SetPaddleDownImage(bool show)
        {
            _paddleArrowDownImage.DOFade(show ? 1 : 0, 0.4f);
        }

        public void SetCursor(bool show)
        {
            _cursor.DOFade(show ? 1 : 0, 0.2f);
        }

        public void SetCooldownUI(float value)
        {
            value = Mathf.Clamp01(value);
            _cooldown.fillAmount = value;

            if (value is 0 or 1)
            {
                _cooldown.DOFade(0, 0.5f);
            }
            else
            {
                _cooldown.DOFade(1, 0.2f);
            }
        }

        #endregion
    }


    [Serializable]
    public struct WheelButton
    {
        public WeaponWheelButtonController ButtonController;
        public Vector2 Angle;
    }
}