using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timeToDestroy = 1f;
    public int damageAmount = 1;
    public float speedProjectile = 50f;
    public List<string> tagsToHit;
    public List<string> tagsToIgnore;
    private void Awake()
    {
        Destroy(gameObject,timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speedProjectile * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (tagsToIgnore.Contains(other.transform.tag))
        {
            return;
        }
        foreach (var tagTarget in tagsToHit)
        {
            if (other.transform.CompareTag(tagTarget))
            {
                var damageable = other.transform.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    Vector3 direction = other.transform.position - transform.position;
                    direction = -direction.normalized;
                    direction.y = 0;
                    damageable.Damage(damageAmount, direction);
                }
            }
            break;
        }
        Destroy(gameObject);
    }
}
