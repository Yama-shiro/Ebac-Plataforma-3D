using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class SO_Interface_Update : MonoBehaviour
{
    public SO_Int soInt;
    public TextMeshProUGUI uiTextValue;

    private void Update()
    {
        uiTextValue.text = soInt.value.ToString();
    }
}
