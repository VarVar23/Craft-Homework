using Gameplay.Craft;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CraftInstaller : MonoInstaller
{
    [SerializeField] private List<IngredientView> _ingredientViews;
    [SerializeField] private ResultView _resultView;
    [SerializeField] private RecipesConfig _recipesConfig;

    public override void InstallBindings()
    {
        Container.Bind<List<IngredientView>>().FromInstance(_ingredientViews).AsSingle();
        Container.Bind<ResultView>().FromInstance(_resultView).AsSingle();

        Container.Bind<ICompareRecipesService>().To<CompareRecipesService>().AsSingle();
        Container.Bind<IItemsFillerService>().To<ItemsFillerService>().AsSingle();
        Container.Bind<IFactoryOpenedItems>().To<FactoryOpenedItems>().AsSingle();

        Container.BindInterfacesAndSelfTo<Controller>().AsSingle();

        Container.Bind<RecipesConfig>().FromInstance(_recipesConfig).AsSingle();
    }
}