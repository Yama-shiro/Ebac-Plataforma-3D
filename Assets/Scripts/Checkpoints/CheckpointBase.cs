using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CheckpointBase : MonoBehaviour
{
    public TypeSfx typeSfx;
    public MeshRenderer meshRenderer;
    public int key = 1;
    private bool _checkpointActived = false;
    private string _emissionColor = "_EmissionColor";
    private string _playerTag = "Player";
    private string _checkpointKey = "CheckpointKey";

    private void Awake()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_checkpointActived && other.CompareTag(_playerTag))
        {
            CheckCheckpoint();
        }
    }

    private void Init()
    {
        TurnOff();
    }
    private void CheckCheckpoint()
    {
        PlaySfx();
        TurnOn();
        SaveCheckpoint();
    }

    #region Turn On/Off
    
        [Button]
        private void TurnOn()
        {
            meshRenderer.material.SetColor(_emissionColor, Color.white);
        }
        [Button]
        private void TurnOff()
        {
            meshRenderer.material.SetColor(_emissionColor, Color.black);
        }
        
    #endregion

    private void SaveCheckpoint()
    {
        /*if (PlayerPrefs.GetInt(_checkpointKey,0) > key)
        {
            PlayerPrefs.SetInt(_checkpointKey,key);
        }*/
        CheckpointManager.Instance.SaveCheckpoint(key);
        _checkpointActived = true;
    }
    private void PlaySfx()
    {
        SfxPool.Instance.Play(typeSfx);
    }
}
