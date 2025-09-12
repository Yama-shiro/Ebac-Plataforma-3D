using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayLevel : MonoBehaviour
{
    public TextMeshProUGUI uiTextName;
    private void Start()
    {
        SaveManager.Instance.fileLoadedAction += OnLoad;
    }

    public void OnLoad(SaveSetup saveSetup)
    {
        uiTextName.text = "Play " + (saveSetup.lastLevel + 1);
    }

    private void OnDestroy()
    {
        SaveManager.Instance.fileLoadedAction -= OnLoad;
    }
}
