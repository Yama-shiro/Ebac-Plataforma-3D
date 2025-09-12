using System.Collections;
using System.Collections.Generic;
using Collectables;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using Collectables;
public class ChestItemCoin : ChestItemBase
{
    public int coinNumber = 5;
    public GameObject coin;
    private List<GameObject> _items = new List<GameObject>();
    public float tweenDuration = 0.2f;
    public Ease ease = Ease.OutBack;
    public Vector2 randomRange = new Vector2(-2f,2f);
    public float itemMove = 2f;
    public float timeItemMove = 1f;
    public override void ShowItem()
    {
        base.ShowItem();
        CreateItems();
    }

    [Button]
    private void CreateItems()
    {
        for (int i = 0; i < coinNumber; i++)
        {
            var item = Instantiate(coin);
            item.transform.position = transform.position + Vector3.forward * 
                Random.Range(randomRange.x,randomRange.y) + Vector3.right * 
                Random.Range(randomRange.x,randomRange.y);
            item.transform.DOScale(0,tweenDuration).SetEase(ease).From();
            _items.Add(item);
        }
    }
    [Button]
    public override void Collect()
    {
        base.Collect();
        foreach (var i in _items)
        {
            i.transform.DOMoveY(itemMove,timeItemMove).SetRelative();
            i.transform.DOScale(0,timeItemMove/2).SetDelay(timeItemMove/2);
            CollectableManager.Instance.AddByType(CollectablesType.Coin);
        }
    }
}
