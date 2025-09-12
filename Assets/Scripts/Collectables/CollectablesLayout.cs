using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Collectables
{
    public class CollectablesLayout : MonoBehaviour
    {
        private CollectablesSetup _currentSetup;
        public Image uiIcon;
        public TextMeshProUGUI uiValue;

        public void Load(CollectablesSetup collectables)
        {
            _currentSetup = collectables;
            UpdateUI();
        }

        private void UpdateUI()
        {
            uiIcon.sprite = _currentSetup.icon;
        }
        private void Update()
        {
            uiValue.text = _currentSetup.soInt.value.ToString();
        }
    }
}
