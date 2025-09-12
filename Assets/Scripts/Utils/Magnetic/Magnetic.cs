using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    public float distance = 0.2f;
    public float speedCoin = 2f;
    public float forceMagnetic = 1f;
    private void Update()
    {
        if (Vector3.Distance(transform.position,Player.Instance.transform.position) > distance)
        {
            speedCoin += forceMagnetic;
            transform.position = Vector3.MoveTowards(transform.position,
                Player.Instance.transform.position,Time.deltaTime * speedCoin);
        }
    }
}
