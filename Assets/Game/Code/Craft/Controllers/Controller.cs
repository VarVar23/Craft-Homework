using System;
using System.Collections.Generic;
using Zenject;

namespace Gameplay.Craft
{
    public class Controller : IInitializable, IDisposable
    {
        private IFactoryOpenedItems _factoryOpenedItems;
        private ICompareRecipesService _compareRecipesService;
        private IItemsFillerService _fillerService;
        private List<IngredientView> _ingredientViews;
        private ResultView _resultView;

        public Controller(IFactoryOpenedItems factory, ICompareRecipesService compareRecipesService, List<IngredientView> ingredientViews, ResultView resultView, IItemsFillerService fillerService)
        {
            _factoryOpenedItems = factory;
            _compareRecipesService = compareRecipesService;
            _fillerService = fillerService;
            _ingredientViews = ingredientViews;
            _resultView = resultView;
        }

        public void Initialize()
        {
            OpenedItems openedItems = _factoryOpenedItems.Create();

            _fillerService.LoadOpenedItems(openedItems);
            _compareRecipesService.LoadOpenedItems(openedItems);
            _compareRecipesService.FoundOldItem += _resultView.SetText;
            _compareRecipesService.FoundNewItem += _resultView.SetText;
            _compareRecipesService.FoundNewItem += _fillerService.FoundNewItem;

            for (int i = 0; i < _ingredientViews.Count; i++)
                _ingredientViews[i].OnDropdownChanged += _compareRecipesService.CompareRecipes;

            _fillerService.UpdateIngredientDropdowns();
        }

        public void Dispose()
        {
            _compareRecipesService.FoundOldItem -= _resultView.SetText;
            _compareRecipesService.FoundNewItem -= _resultView.SetText;
            _compareRecipesService.FoundNewItem -= _fillerService.FoundNewItem;

            for (int i = 0; i < _ingredientViews.Count; i++)
                _ingredientViews[i].OnDropdownChanged -= _compareRecipesService.CompareRecipes;
        }
    }
}