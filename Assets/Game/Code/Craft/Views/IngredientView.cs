using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gameplay.Craft
{
    public class IngredientView : MonoBehaviour
    {
        public event Action OnDropdownChanged;
        [SerializeField] private TMP_Dropdown _dropdown;

        private void OnEnable() => _dropdown.onValueChanged.AddListener(DropdownChanged);
        private void OnDisable() => _dropdown.onValueChanged.RemoveListener(DropdownChanged);

        public void UpdateItems(List<string> value)
        {
            _dropdown.ClearOptions();
            _dropdown.AddOptions(value);
        }

        public string GetItem()
        {
            return _dropdown.captionText.text;
        }

        private void DropdownChanged(int value)
        {
            OnDropdownChanged?.Invoke();
        }
    }
}