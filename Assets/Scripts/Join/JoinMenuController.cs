using TMPro;
using UnityEngine;

public class JoinMenuController : MonoBehaviour {

    public TMP_Text PlayerText;
    public GameObject ReadyText;

    private int _playerIndex;

    private float _currentIgnoreInputTime;
    private float _ignoreInputTime = 1.5f;
    private bool _inputEnabled;

    private void Update() {
        if (Time.time > _ignoreInputTime) {
            _inputEnabled = true;
        }
    }

    public void SetPlayerIndex(int index) {
        _playerIndex = index;
        
        PlayerText.text = "Player " + (index + 1);
    }

    public void StartGame() {
        JoinManager.Instance.StartGame();
    }

    public void ToggleReady() {
        if (!_inputEnabled) {
            return;
        }
        
        bool isReady = JoinManager.Instance.ToggleReady(_playerIndex);
        
        ReadyText.SetActive(isReady);
    }

    public void DeviceLostEvent() {
        Debug.Log("Lost player " + _playerIndex);
        
        JoinManager.Instance.RemovePlayer(_playerIndex);
    } 
}
