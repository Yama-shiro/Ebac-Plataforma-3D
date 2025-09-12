using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class DestructableBase : MonoBehaviour
{
    public HealthBase healthBase;
    public float tweenShake = 0.1f;
    public int tweenForce = 1;
    public int dropCoinsAmount = 10;
    public GameObject coin;
    public Transform dropPosition;
    public float scaleDuration = 1f;
    public Ease ease = Ease.OutBack;
    public float dropTime = 0.2f;

    private void Awake()
    {
        OnValidate();
        healthBase.onDamage += OnDamage;
    }

    private void OnValidate()
    {
        if (healthBase == null)
        {
            healthBase = GetComponent<HealthBase>();
        }
    }

    private void OnDamage(HealthBase hb)
    {
        transform.DOShakeScale(tweenShake,Vector3.up/2,tweenForce);
        DropGroupCoins();
    }

    [Button]
    private void DropCoins()
    {
        var i = Instantiate(coin);
        i.transform.position = dropPosition.position;
        i.transform.DOScale(0,scaleDuration).SetEase(ease).From();
    }
    [Button]
    private void DropGroupCoins()
    {
        StartCoroutine(nameof(CoroutineDropGroupCoins));
    }

    IEnumerator CoroutineDropGroupCoins()
    {
        for (int i = 0; i < dropCoinsAmount; i++)
        {
            DropCoins();
            yield return new WaitForSeconds(dropTime);
        }
    }
}
