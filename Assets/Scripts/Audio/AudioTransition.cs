using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioTransition : MonoBehaviour
{
    public AudioMixerSnapshot snapshotMute;
    public AudioMixerSnapshot snapshotOn;
    public float transitionTime = 0.1f;
    private bool _sound = false;

    private void Awake()
    {
        Play();
    }

    public void OnClick()
    {
        if (_sound)
        {
            Play();
        }
        else
        {
            Mute();
        }
        _sound = !_sound;
    }
    [Button]
    public void Mute()
    {
        snapshotMute.TransitionTo(transitionTime);
        ChangeColor(Color.red);
    }

    [Button]
    public void Play()
    {
        snapshotOn.TransitionTo(transitionTime);
        ChangeColor(Color.green);
    }

    private void ChangeColor(Color color)
    {
        GetComponent<Image>().color = color;
    }
}
