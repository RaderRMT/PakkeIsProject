using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JoinManager : MonoBehaviour {

    public static JoinManager Instance { get; private set; }

    public GameObject JoinScreenMenuList;
    public string GameSceneName;

    private List<PlayerInformation> _playerInformations = new List<PlayerInformation>();

    private JoinManager() {
        Instance = this;
    }

    public bool ToggleReady(int index) {
        return _playerInformations[index].IsReady = !_playerInformations[index].IsReady;
    }

    public bool IsEveryoneReady() {
        return _playerInformations.TrueForAll(player => player.IsReady);
    }

    public void StartGame() {
        if (!IsEveryoneReady()) {
            return;
        }

        SceneManager.LoadScene(GameSceneName);
    }

    public void PlayerJoinedEvent(PlayerInput input) {
        if (_playerInformations.Any(player => player.PlayerIndex == input.playerIndex)) {
            return;
        }
        
        Debug.Log("Player joined: " + input.playerIndex);
        input.transform.SetParent(JoinScreenMenuList.transform);

        JoinMenuController controller = input.gameObject.GetComponent<JoinMenuController>();
        controller.SetPlayerIndex(input.playerIndex);
            
        _playerInformations.Add(new PlayerInformation(input));
    }

    public void RemovePlayer(int index) {
        PlayerInformation player = _playerInformations.Find(player => player.PlayerIndex == index);
        
        _playerInformations.Remove(player);
        
        Destroy(player.Input.gameObject);
    }

    public List<PlayerInformation> GetPlayerInfos() {
        return _playerInformations;
    }
}
