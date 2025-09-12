using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase projectileBase;
    public Transform positionToShoot;
    public float timeBetweenShoot = 0.2f;
    private Coroutine _currentCoroutine;
    public float speedProjectile = 50f;

    
    protected virtual void Shoot()
    {
        var projectile = Instantiate(projectileBase);
        projectile.transform.position = positionToShoot.position; 
        projectile.transform.rotation = positionToShoot.rotation;
        projectile.speedProjectile = speedProjectile;
        CameraShake.Instance.Shake();
    }

    public void StartShoot()
    {
        StopShoot();
        _currentCoroutine = StartCoroutine(nameof(CoroutineShoot));
    }

    public void StopShoot()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(nameof(CoroutineShoot));
        }
    }
    protected virtual IEnumerator CoroutineShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

}
