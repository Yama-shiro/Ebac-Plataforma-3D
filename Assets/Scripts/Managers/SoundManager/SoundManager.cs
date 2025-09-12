using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class SoundManager : Singleton<SoundManager>
{
    public List<MusicSetup> musicSetups;
    public List<SfxSetup> sfxSetups;
    public AudioSource musicSource;

    public void PlayMusicByType(TypeMusic typeMusic)
    {
        var music = GetMusicByType(typeMusic);
        musicSource.clip = music.audioClip;
        musicSource.Play();
    }
    public MusicSetup GetMusicByType(TypeMusic typeMusic)
    {
        return musicSetups.Find(i => i.typeMusic == typeMusic);
        
    }
    public SfxSetup GetSfxByType(TypeSfx typeSfx)
    {
        return sfxSetups.Find(i => i.typeSfx == typeSfx);
        
    }
}

public enum TypeMusic
{
    Type01,
    Type02,
    Type03
}
public enum TypeSfx
{
    None,
    Coin,
    LifePack,
    Checkpoint,
    ChestOpen
}
[Serializable]
public class MusicSetup
{
    public TypeMusic typeMusic;
    public AudioClip audioClip;
}
[Serializable]
public class SfxSetup
{
    public TypeSfx typeSfx;
    public AudioClip audioClip;
}
