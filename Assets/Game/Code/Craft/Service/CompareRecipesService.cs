using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Craft
{
    public class CompareRecipesService : ICompareRecipesService
    {
        public event Action<string> FoundNewItem;
        public event Action<string> FoundOldItem;

        private List<IngredientView> _ingredientViews;
        private RecipesConfig _recipesConfig;
        private OpenedItems _openedItems;

        public CompareRecipesService(List<IngredientView> ingredientViews, RecipesConfig recipesConfig)
        {
            _ingredientViews = ingredientViews;
            _recipesConfig = recipesConfig;
        }

        public void LoadOpenedItems(OpenedItems openedItems)
        {
            _openedItems = openedItems;
        }

        public void CompareRecipes()
        {
            List<string> currentItems = GetCurrentItems();
            string item = TryGetResultItem(currentItems);

            if (item == null) return;

            if (CheckItemIsOpen(item))
            {
                FoundOldItem?.Invoke(item);
            }
            else
            {
                FoundNewItem?.Invoke(item);
            }
        }

        private string TryGetResultItem(List<string> currentItems)
        {
            for (int i = 0; i < _recipesConfig.Recipes.Count; i++)
            {
                var needItems = _recipesConfig.Recipes[i].NeedItems;

                if (currentItems.Count != needItems.Count) continue;

                for (int j = 0; j < needItems.Count; j++)
                {
                    if (currentItems[j] != needItems[j]) break;

                    if (j + 1 == needItems.Count)
                    {
                        return _recipesConfig.Recipes[i].Result;
                    }
                }
            }

            return null;
        }

        private bool CheckItemIsOpen(string item)
        {
            if(_openedItems == null)
            {
                Debug.LogError("Data opened items not loaded");
                return false;
            }

            for (int i = 0; i < _openedItems.Items.Count; i++)
            {
                if (_openedItems.Items[i] == item)
                {
                    return true;
                }
            }

            return false;
        }

        private List<string> GetCurrentItems()
        {
            List<string> currentItems = new();

            for (int i = 0; i < _ingredientViews.Count; i++)
            {
                string item = _ingredientViews[i].GetItem();

                if (item == null || item == string.Empty) continue;

                currentItems.Add(item);
            }

            return currentItems;
        }
    }
}