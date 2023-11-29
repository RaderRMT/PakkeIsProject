using UnityEngine;
using UnityEngine.InputSystem;

public class CreditsManager : MonoBehaviour {

    public Canvas MainMenuCanvas;
    public Canvas CreditsCanvas;

    void Update() {
        if (!CreditsCanvas.enabled) {
            return;
        }
            
        if (Input.inputString.Equals("")) {
            return;
        }

        DisableScreen();
    }

    public void GoBack(InputAction.CallbackContext context) {
        if (!CreditsCanvas.enabled) {
            return;
        }
        
        if (!context.performed) {
            return;
        }
        
        DisableScreen();
    }

    private void DisableScreen() {
        CreditsCanvas.enabled = false;
        MainMenuCanvas.enabled = true;
    }
}
