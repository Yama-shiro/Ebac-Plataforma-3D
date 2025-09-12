using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunShootLimit : GunBase
{
    public List<UIUpdaterGun> uiGunUpdaters;
    public float maxShoot = 5f;
    public float timeToRecharge = 1f;
    private float _currentShoots;
    private bool _recharging = false;

    private void Awake()
    {
        GetAllUIs();
    }

    protected override IEnumerator CoroutineShoot()
    { 
        if (_recharging)
        {
            yield break;
        }
        while (true)
        {
            if (_currentShoots < maxShoot)
            {
                Shoot();
                _currentShoots++;
                CheckRecharge();
                UpdateUI();
                yield return new WaitForSeconds(timeBetweenShoot);
            }
        }
    }

    private void CheckRecharge()
    {
        if (_currentShoots >= maxShoot)
        {
            StopShoot();
            StartRecharge();
        }
    }

    private void StartRecharge()
    {
        _recharging = true;
        StartCoroutine(nameof(CoroutineRecharge));
    }

    private IEnumerator CoroutineRecharge()
    {
        float time = 0;
        while (time < timeToRecharge)
        {
            time += Time.deltaTime;
            uiGunUpdaters.ForEach(i => i.UpdateValues(time/timeToRecharge));
            yield return new WaitForEndOfFrame();
        }
        _currentShoots = 0;
        _recharging = false;
    }

    private void UpdateUI()
    {
        uiGunUpdaters.ForEach(i => i.UpdateValue(maxShoot,_currentShoots));
    }

    private void GetAllUIs()
    {
        uiGunUpdaters = GameObject.FindObjectsOfType<UIUpdaterGun>().ToList();
    }
}
