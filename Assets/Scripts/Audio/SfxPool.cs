using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using UnityEngine.Audio;

public class SfxPool : Singleton<SfxPool>
{
    private List<AudioSource> _audioSources;
    public AudioMixerGroup audioGroup;
    public int poolSize = 10;
    private int _index = 0;

    private void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _audioSources = new List<AudioSource>();
        for (int i = 0; i < poolSize; i++)
        {
            CreateAudioSourceItem();
        }
    }

    private void CreateAudioSourceItem()
    {
        GameObject gameObjectPool = new GameObject("SFX_Pool");
        gameObjectPool.transform.SetParent(gameObject.transform);
        _audioSources.Add(gameObjectPool.AddComponent<AudioSource>());
        gameObjectPool.GetComponent<AudioSource>().outputAudioMixerGroup = audioGroup;
    }

    public void Play(TypeSfx typeSfx)
    {
        if (typeSfx == TypeSfx.None)
        {
            return;
        }
        var sfx = SoundManager.Instance.GetSfxByType(typeSfx);
        _audioSources[_index].clip = sfx.audioClip;
        _audioSources[_index].Play();
        _index++;
        if (_index >= _audioSources.Count)
        {
            _index = 0;
        }
    }
}
