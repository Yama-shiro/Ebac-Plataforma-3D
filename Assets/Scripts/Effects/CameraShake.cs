using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using Cinemachine;
using NaughtyAttributes;

public class CameraShake : Singleton<CameraShake>
{
    public CinemachineVirtualCamera virtualCamera;
    public float shakeTime;
    public CinemachineBasicMultiChannelPerlin basicMultiChannelPerlin;
    [Header("Shake Values")] 
        public float amplitude = 3f;
        public float frequency = 3f;
        public float time = 0.2f;

    private void Update()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }
        else
        {
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0f;   
        }
    }
    [Button]
    public void Shake()
    {
        ShakeValues(amplitude,frequency,time);
    }
    public void ShakeValues(float amplitude,float frequency,float time)
    {
        //basicMultiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;  
        shakeTime = time;
    }
}
