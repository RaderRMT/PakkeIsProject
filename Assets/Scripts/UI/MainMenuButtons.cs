using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

    [Header("Start Game Button Stuff")]
    public string GameScene;

    [Header("Credits Button Stuff")]
    public Canvas MainMenuCanvas;
    public Canvas CreditsCanvas;

    public void StartGame() {
        SceneManager.LoadScene(GameScene);
    }

    public void ShowCredits() {
        MainMenuCanvas.enabled = false;
        CreditsCanvas.enabled = true;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
