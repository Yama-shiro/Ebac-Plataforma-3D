using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public TypeSfx typeSfx;
    public KeyCode keyCode = KeyCode.O;
    public Animator animator;
    public string triggerOpen = "Open";
    private bool _chestOpened = false;
    public float timeShowObject = 1f;
    [Header("Notification")]
        public GameObject notification;
        public float tweenDuration = 0.2f;
        public Ease ease = Ease.OutBack;
        private float _scaleStart;
    [Space] 
        public ChestItemBase chestItemBase;

    private void Start()
    {
        _scaleStart = notification.transform.localScale.x;
        HideNotification();
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode) && notification.activeSelf)
        {
            OpenChest();
        }
    }

    [Button]
    private void OpenChest()
    {
        if (_chestOpened)
        {
            return;
        }
        PlaySfx();
        _chestOpened = true;
        animator.SetTrigger(triggerOpen);
        HideNotification();
        Invoke(nameof(ShowItem),timeShowObject);    
    }

    private void ShowItem()
    {
        chestItemBase.ShowItem();
        Invoke(nameof(CollectItem),timeShowObject);  
    }
    private void CollectItem()
    {
        chestItemBase.Collect();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.transform.GetComponent<Player>();
        if (player != null)
        {
            ShowNotification();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Player player = other.transform.GetComponent<Player>();
        if (player != null)
        {
            HideNotification();
        }
    }
    [Button]
    private void ShowNotification()
    {
        notification.SetActive(true);
        notification.transform.localScale = Vector3.zero;
        notification.transform.DOScale(_scaleStart,tweenDuration);
    }
    [Button]
    private void HideNotification()
    {
        notification.SetActive(false);
    }
    private void PlaySfx()
    {
        SfxPool.Instance.Play(typeSfx);
    }
}
