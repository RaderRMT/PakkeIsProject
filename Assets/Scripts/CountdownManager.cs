using System;
using UnityEngine;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour {

    public Canvas Canvas;
    public RawImage CountdownRawImage;

    public Texture[] CountdownTextures;
    public float TimeBeforeCountdownStart;

    public SoundManager SoundManager;

    private int currentTexture = 3;
    private float _currentCountdownTime = 3;
    private float _currentTimeBeforeCountdownStart;

    private Action _onCooldownOver;

    private void Start() {
        Canvas.enabled = false;

        CountdownRawImage.color = Color.clear;
        SetCountdownImage(CountdownTextures.Length - 1);
    }

    private void SetCountdownImage(int index) {
        Texture texture = CountdownTextures[index];
        
        CountdownRawImage.texture = texture;
        CountdownRawImage.rectTransform.sizeDelta = new Vector2(texture.width / 3, texture.height / 3);
    }

    private void Update() {
        if (!Canvas.enabled) {
            return;
        }

        if (_currentTimeBeforeCountdownStart < TimeBeforeCountdownStart) {
            _currentTimeBeforeCountdownStart += Time.deltaTime;
            return;
        }
        
        CountdownRawImage.color = Color.white;
        
        _currentCountdownTime -= Time.deltaTime;
        if (_currentCountdownTime <= 0 && _onCooldownOver != null) {
            _onCooldownOver.Invoke();
            _onCooldownOver = null;
        }
        
        if (_currentCountdownTime <= -1) {
            Canvas.enabled = false;
            return;
        }

        int seconds = Mathf.CeilToInt(_currentCountdownTime);
        if (seconds == currentTexture) {
            return;
        }

        currentTexture = seconds;
        SetCountdownImage(currentTexture);
    }

    public void ShowCountdown(Action onCooldownOver) {
        Canvas.enabled = true;
        _onCooldownOver = onCooldownOver;

        SoundManager.PlayBackgroundSong();
    }
}

