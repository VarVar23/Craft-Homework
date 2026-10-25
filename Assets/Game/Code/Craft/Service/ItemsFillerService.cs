using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Craft
{
    public class ItemsFillerService : IItemsFillerService
    {
        private List<IngredientView> _views;
        private OpenedItems _openedItems;

        public ItemsFillerService(List<IngredientView> views)
        {
            _views = views;
        }

        public void LoadOpenedItems(OpenedItems openedItems)
        {
            _openedItems = openedItems;
        }

        public void FoundNewItem(string item)
        {
            _openedItems.Items.Add(item);
            UpdateIngredientDropdowns();
        }

        public void UpdateIngredientDropdowns()
        {
            if (_openedItems == null)
            {
                Debug.LogError("Data opened items not loaded");
                return;
            }

            for (int i = 0; i < _views.Count; i++)
            {
                _views[i].UpdateItems(_openedItems.Items);
            }
        }
    }
}