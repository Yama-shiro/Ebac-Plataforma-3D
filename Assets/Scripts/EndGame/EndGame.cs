using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    public List<GameObject> endGameObjects;
    public float tweenDuration = 0.2f;
    public Ease ease = Ease.OutBack;
    public int currentLevel = 1;
    private bool _endGame = false;

    private void Awake()
    {
        endGameObjects.ForEach(i => i.SetActive(false));
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.transform.GetComponent<Player>();
        if (!_endGame && player != null)
        {
            ShowEndGame();
        }
    }

    private void ShowEndGame()
    {
        _endGame = true;
        foreach (var i in endGameObjects)
        {
            i.SetActive(true);
            i.transform.DOScale(0f,tweenDuration).SetEase(ease).From();
            SaveManager.Instance.SaveLastLevel(currentLevel);
        }
    }
}
