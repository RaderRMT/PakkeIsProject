using UnityEngine;
using UnityEngine.InputSystem;
using WaterAndFloating;

public class LevelInitializer : MonoBehaviour {
    
    public GameObject PlayerPrefab;
    public Waves Waves;
    public Transform[] PlayerSpawnPositions;

    void Start() {
        PlayerInformation[] infos = JoinManager.Instance.GetPlayerInfos().ToArray();

        for (int i = 0; i < infos.Length; i++) {
            Transform spawnPosition = PlayerSpawnPositions[i];

            GameObject player = Instantiate(PlayerPrefab, spawnPosition.position, spawnPosition.rotation, gameObject.transform);

            infos[i].Input = player.GetComponent<PlayerInput>();
            player.GetComponent<PlayerInputHandler>().InitializePlayer(infos[i]);
            player.GetComponent<PlayerController>().Waves = Waves;
            Waves.PlayerTransforms.Add(player.transform);
        }
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmos() {
        foreach (Transform transform in PlayerSpawnPositions) {
            Gizmos.DrawSphere(transform.position, 1f);
        }
    }
#endif
}
