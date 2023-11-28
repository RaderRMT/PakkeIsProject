using UnityEngine;

public class CreditsManager : MonoBehaviour {

    public Canvas MainMenuCanvas;
    public Canvas CreditsCanvas;

    void Update() {
        if (!Input.anyKey) {
            return;
        }

        CreditsCanvas.enabled = false;
        MainMenuCanvas.enabled = true;
    }
}
