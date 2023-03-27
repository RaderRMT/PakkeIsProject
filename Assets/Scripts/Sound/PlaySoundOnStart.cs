using System;
using System.Collections;
using System.Collections.Generic;
using Sound;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        SoundManager.Instance.PlaySound(_clip);
    }
}
