using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour {

    private PlayerInformation _playerInformation;
    private PlayerController _playerController;

    private PlayInputs _inputs;

    private int _deviceId;

    private void Awake() {
        _playerController = GetComponent<PlayerController>();
        
        _inputs = new PlayInputs();
    }

    public void InitializePlayer(PlayerInformation playerInformation) {
        _playerInformation = playerInformation;

        _deviceId = _playerInformation.DeviceId;
        
        _playerInformation.Input.onActionTriggered += OnActionTriggered;
    }

    private void OnActionTriggered(InputAction.CallbackContext context) {
        if (context.control.device.deviceId != _deviceId) {
            return;
        }
        
        if (context.action.name == _inputs.Play.PaddleLeft.name) {
            _playerController.PaddleLeft(context);
        }
        
        if (context.action.name == _inputs.Play.PaddleRight.name) {
            _playerController.PaddleRight(context);
        }
    }
}
