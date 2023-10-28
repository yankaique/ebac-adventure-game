using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Item
{
    public class ItemLayout : MonoBehaviour
    {
        private ItemSetup _currentSetup;

        public Image uiIcon;
        public TextMeshProUGUI uiText;

        public void load(ItemSetup setup)
        {
            _currentSetup = setup;
            UpdateUI();
        }

        private void UpdateUI()
        {
            uiIcon.sprite = _currentSetup.icon;
        }

        private void Update()
        {
            uiText.text = _currentSetup.soInt.value.ToString();
        }
    }
}
