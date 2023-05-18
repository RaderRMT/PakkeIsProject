using UnityEngine;

namespace Sound
{
    public class MusicChangeTrigger : MonoBehaviour
    {
        [Header("Area")]
        [SerializeField] private MusicArea area;
        public void SetMusic()
        {
            AudioManager.Instance.SetMusicArea(area);
            Debug.Log("Type de la musique mise � jour");
        }
    }
}
