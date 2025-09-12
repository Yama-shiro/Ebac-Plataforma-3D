using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartCheck : MonoBehaviour
{
    public string tagToCheck = "Player";
    public GameObject bossCamera;
    public Color colorGizmos = Color.cyan;
    private void Awake()
    {
        CameraTurnOff();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCheck))
        {
            CameraTurnOn();
        }
    }

    private void CameraTurnOn()
    {
        bossCamera.SetActive(true);
    }
    private void CameraTurnOff()
    {
        bossCamera.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = colorGizmos;
        Gizmos.DrawSphere(transform.position,transform.localScale.y);
    }
}
