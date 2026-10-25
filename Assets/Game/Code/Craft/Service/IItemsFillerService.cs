namespace Gameplay.Craft
{
    public interface IItemsFillerService
    {
        void LoadOpenedItems(OpenedItems openedItems);
        void FoundNewItem(string item);
        void UpdateIngredientDropdowns();
    }
}