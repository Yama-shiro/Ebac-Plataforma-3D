using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Serialization;
using Cloth;

public class HealthBase : MonoBehaviour, IDamageable
{
    public float startLife = 10f;
    public float timeToDestroy = 3f;
    public bool destroyOnKill = false;
    public float damageMultiply = 1f;
    public Action<HealthBase> onDamage;
    public Action<HealthBase> onKill;
    public List<UIUpdater> uiUpdaters;
    [SerializeField] private float _currentLife;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        ResetLife();
    }
    public void ResetLife()
    {
        _currentLife = startLife;
        UpdateUI();
    }
    protected virtual void Kill()
    {
        if (destroyOnKill)
        {
            Destroy(gameObject, timeToDestroy);
        }
        onKill?.Invoke(this);
    }
    [Button]
    public void DamageTest()
    {
        Damage(5f);
    }
    public void Damage(float damage)
    { 
        _currentLife -= damage * damageMultiply;
        if (_currentLife <= 0)
        {
            Kill();
        }
        UpdateUI();
        onDamage?.Invoke(this);
    }

    public void Damage(float damage, Vector3 direction)
    {
        Damage(damage);
    }

    private void UpdateUI()
    {
        if (uiUpdaters != null)
        {
            uiUpdaters.ForEach(i => i.UpdateValues((float) _currentLife/ startLife));
        }
    }
    public void ChangeDamageMultiply(float damage, float duration)
    {
        StartCoroutine(CoroutineChangeDamageMultiply(damage,duration));
    }
    private IEnumerator CoroutineChangeDamageMultiply(float multiply, float duration)
    {
        damageMultiply = multiply;
        yield return new WaitForSeconds(duration);
        damageMultiply = 1f;
    }
}
