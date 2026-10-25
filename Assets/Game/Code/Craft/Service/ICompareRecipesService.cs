using System;

namespace Gameplay.Craft
{
    public interface ICompareRecipesService
    {
        event Action<string> FoundNewItem;
        event Action<string> FoundOldItem;

        void LoadOpenedItems(OpenedItems openedItems);
        void CompareRecipes();
    }
}