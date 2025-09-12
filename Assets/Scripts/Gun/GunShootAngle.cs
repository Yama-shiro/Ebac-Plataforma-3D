using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootAngle : GunShootLimit
{
    public int amountPerShoot = 4;
    public float angle = 15f;

    protected override void Shoot()
    {
        int multiplier = 0;
        for (int i = 0; i < amountPerShoot; i++)
        {
            if (i%2 == 0)
            {
                multiplier++;
            }
            var projectile = Instantiate(projectileBase,positionToShoot);
            projectile.transform.localPosition = Vector3.zero;
            projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * 
                (i%2 == 0 ? angle : -angle) * multiplier;
            projectile.speedProjectile = speedProjectile;
            projectile.transform.parent = null;
        }
    }
}
