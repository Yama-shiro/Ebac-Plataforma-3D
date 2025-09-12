using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Collectables;

public class MagneticTriggerPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CollectableBase i = other.transform.GetComponent<CollectableBase>();
        if (i != null)
        {
            i.transform.AddComponent<Magnetic>();
        }
    }
}
