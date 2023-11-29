using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public Canvas MainMenuCanvas;
    public Button[] Buttons;

    private int _selectedButton;

    private void Start() {
        Buttons[0].image.color = Buttons[0].colors.pressedColor;
    }

    public void MoveUp(InputAction.CallbackContext context) {
        if (!MainMenuCanvas.enabled) {
            return;
        }

        if (!context.performed) {
            return;
        }
        
        Debug.Log("Move Up");
        int previousButton = _selectedButton;
        
        _selectedButton--;
        if (_selectedButton < 0) {
            _selectedButton = Buttons.Length - 1;
        }

        UpdateButtonStyle(previousButton, _selectedButton);
    }

    public void MoveDown(InputAction.CallbackContext context) {
        if (!MainMenuCanvas.enabled) {
            return;
        }
        
        if (!context.performed) {
            return;
        }
        
        Debug.Log("Move Down");
        int previousButton = _selectedButton;
        
        _selectedButton++;
        _selectedButton %= Buttons.Length;

        UpdateButtonStyle(previousButton, _selectedButton);
    }

    public void Select(InputAction.CallbackContext context) {
        if (!MainMenuCanvas.enabled) {
            return;
        }
        
        if (!context.performed) {
            return;
        }
        
        Buttons[_selectedButton].onClick.Invoke();
    }

    private void UpdateButtonStyle(int previousButton, int currentButton) {
        Buttons[previousButton].image.color = Buttons[previousButton].colors.normalColor;
        Buttons[currentButton].image.color = Buttons[currentButton].colors.pressedColor;
    }
}

