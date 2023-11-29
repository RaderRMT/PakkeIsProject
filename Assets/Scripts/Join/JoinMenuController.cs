using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JoinMenuController : MonoBehaviour {

    public TMP_Text PlayerText;
    public GameObject ReadyText;
    public PlayerInput PlayerInput;
    public RawImage PlayerColorImage;
    public List<Texture> PlayerTextures;
    
    public PlayerController PlayerController { get; set; }

    private CommonInputs _inputs;

    private int _playerIndex;

    private float _currentIgnoreInputTime;

    public bool IsPlaying { get; set; }
    
    private void Start() {
        _inputs = new CommonInputs();

        PlayerInput.onActionTriggered += ActionTriggered;
        PlayerInput.onDeviceLost += DeviceLostEvent;
    }

    private void ActionTriggered(InputAction.CallbackContext context) {
        if (IsPlaying) {
            if (context.action.name == _inputs.All.Paddle.name) {
                PlayerController.PaddleForward(context.action.IsPressed());
            }
            
            if (context.action.name == _inputs.All.UseItem.name) {
                PlayerController.gameObject.GetComponent<AttackController>().UseHeldItem();
            }
            
            if (context.action.name == _inputs.All.TurnLeft.name) {
                PlayerController.Turn(PlayerController.Direction.LEFT, context.action.IsPressed(), context.ReadValue<float>());
            }
            
            if (context.action.name == _inputs.All.TurnRight.name) {
                PlayerController.Turn(PlayerController.Direction.RIGHT, context.action.IsPressed(), context.ReadValue<float>());
            }
        } else {
            if (context.action.name == _inputs.All.Ready.name) {
                ToggleReady();
            }
        
            if (context.action.name == _inputs.All.Start.name) {
                StartGame();
            }
        }
    }

    public void SetPlayerIndex(int index) {
        _playerIndex = index;
        
        PlayerText.text = "Player " + (index + 1);
        PlayerColorImage.texture = PlayerTextures[index];
    }

    public void StartGame() {
        JoinManager.Instance.StartGame();
    }

    public void ToggleReady() {
        bool isReady = JoinManager.Instance.ToggleReady(_playerIndex);
        
        ReadyText.SetActive(isReady);
    }

    public void DeviceLostEvent(PlayerInput playerInput) {
        Debug.Log("Lost player " + _playerIndex);
        
        JoinManager.Instance.RemovePlayer(_playerIndex);
    } 
}
