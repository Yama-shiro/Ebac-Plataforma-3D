using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public TypeMusic typeMusic;
    public AudioSource audioSource;

    private MusicSetup _currentMusicSetup;

    private void Start()
    {
        Play();
    }

    private void Play()
    {
        _currentMusicSetup = SoundManager.Instance.GetMusicByType(typeMusic);
        audioSource.clip = _currentMusicSetup.audioClip;
        audioSource.Play();
    }
}
