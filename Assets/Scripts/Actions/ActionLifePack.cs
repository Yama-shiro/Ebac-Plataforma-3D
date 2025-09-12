using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collectables;

public class ActionLifePack : MonoBehaviour
{
    public SO_Int soInt;
    public KeyCode keyCode = KeyCode.Z;

    private void Start()
    {
        soInt = CollectableManager.Instance.GetCollectableByType(CollectablesType.LifePack).soInt;
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            RecoverLife();
        }
    }

    private void RecoverLife()
    {
        if (soInt.value > 0)
        {
            CollectableManager.Instance.RemoveByType(CollectablesType.LifePack);
            Player.Instance.healthBase.ResetLife();
        }
    }
}
