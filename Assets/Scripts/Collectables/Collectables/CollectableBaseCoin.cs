using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collectables;

public class CollectableBaseCoin : CollectableBase
{
    public Collider2D collider;
    protected override void OnCollect()
    {
        base.OnCollect();
        CollectableManager.Instance.AddByType(CollectablesType.Coin);
        collider.enabled = false;
    }
}
