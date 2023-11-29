using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour {

    public Canvas ScoreScreenCanvas;
    public float TimeBeforeShowingScoreScreen;
    private float _currentTimeBeforeShowingScoreScreen;

    public List<PlayerController> Players { get; } = new List<PlayerController>();

    public GameObject ScoreEntryList;
    public GameObject ScoreEntryPrefab;

    public string MainMenuSceneName;

    void Update() {
        if (ScoreScreenCanvas.enabled) {
            if (Input.anyKey) {
                SceneManager.LoadScene(MainMenuSceneName);
            }
            
            return;
        }

        if (Players.Count == 0) {
            return;
        }
        
        if (Players.Any(p => !p.HasCrossedFinishLine)) {
            return;
        }

        _currentTimeBeforeShowingScoreScreen += Time.deltaTime;
        if (_currentTimeBeforeShowingScoreScreen < TimeBeforeShowingScoreScreen) {
            return;
        }

        ScoreScreenCanvas.enabled = true;
        AddScores();
    }

    private void AddScores() {
        foreach (PlayerController player in Players.OrderBy(p => p.PlayerPositionRawImage.texture.name)) {
            GameObject entry = Instantiate(ScoreEntryPrefab, ScoreEntryList.transform);
            ScoreEntry scoreEntry = entry.GetComponent<ScoreEntry>();
            scoreEntry.Text.text = player.PlayerName;
            scoreEntry.Position.texture = player.PlayerPositionRawImage.texture;
        }
    }
}
