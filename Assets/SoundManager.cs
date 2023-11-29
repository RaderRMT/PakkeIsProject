using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource SongAudioSource;

    public void PlayBackgroundSong() {
        SongAudioSource.Play();
    }
}
