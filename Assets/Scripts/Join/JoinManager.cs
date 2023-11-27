using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using WaterAndFloating;

public class JoinManager : MonoBehaviour {

    public static JoinManager Instance { get; private set; }

    public Canvas JoinScreenCanvas;
    public GameObject JoinScreenMenuList;
    public PlayerInputManager PlayerInputManager;

    public CountdownManager CountdownManager;
    
    public GameObject PlayerPrefab;
    public Waves Waves;
    public Transform[] PlayerSpawnPositions;

    public PositionHandler PositionHandler;

    public List<Texture> PlayerIndexTextures;
    public List<Material> PlayerMaterials;

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

        PlayerInputManager.DisableJoining();

        InitializePlayers();
        JoinScreenCanvas.enabled = false;
        
        PlayerInputManager.splitScreen = true;
        
        CountdownManager.ShowCountdown(() => {
            foreach (PlayerController controller in PositionHandler.PlayerPositions) {
                controller.EnableMovements();
            }
        });
    }

    private void InitializePlayers() {
        PlayerInformation[] infos = GetPlayerInfos().ToArray();

        for (int i = 0; i < infos.Length; i++) {
            Transform spawnPosition = PlayerSpawnPositions[i];

            GameObject player = Instantiate(PlayerPrefab, spawnPosition.position, spawnPosition.rotation);
            PlayerController controller = player.GetComponent<PlayerController>();
            controller.Waves = Waves;

            player.name = "Player " + (infos[i].PlayerIndex + 1);
            controller.InitPlayer(player.name, PlayerIndexTextures[infos[i].PlayerIndex], PlayerMaterials[infos[i].PlayerIndex]);

            infos[i].JoinMenuController.PlayerController = controller;
            infos[i].JoinMenuController.IsPlaying = true;
            infos[i].JoinMenuController.PlayerInput.camera = controller.PlayerCamera;
            
            PositionHandler.PlayerPositions.Add(controller);
            Waves.PlayerTransforms.Add(player.transform);
        }
    }

    public void PlayerJoinedEvent(PlayerInput input) {
        if (_playerInformations.Any(player => player.PlayerIndex == input.playerIndex)) {
            return;
        }
        
        Debug.Log("Player joined: " + input.playerIndex);
        input.transform.SetParent(JoinScreenMenuList.transform);

        JoinMenuController controller = input.gameObject.GetComponent<JoinMenuController>();
        controller.SetPlayerIndex(input.playerIndex);
            
        _playerInformations.Add(new PlayerInformation(input, controller));
    }

    public void RemovePlayer(int index) {
        PlayerInformation player = _playerInformations.Find(player => player.PlayerIndex == index);
        
        _playerInformations.Remove(player);
        
        Destroy(player.Input.gameObject);
    }

    public List<PlayerInformation> GetPlayerInfos() {
        return _playerInformations;
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmos() {
        foreach (Transform transform in PlayerSpawnPositions) {
            Gizmos.DrawSphere(transform.position, 1f);
        }
    }
#endif
}
