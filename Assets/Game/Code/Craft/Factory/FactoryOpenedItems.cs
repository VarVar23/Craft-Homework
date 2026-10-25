using System.Collections.Generic;

namespace Gameplay.Craft
{
    public class FactoryOpenedItems : IFactoryOpenedItems
    {
        private RecipesConfig _recipesConfig;

        public FactoryOpenedItems(RecipesConfig recipesConfig)
        {
            _recipesConfig = recipesConfig;
        }

        public OpenedItems Create()
        {
            List<string> unlockAtStart = new();
            var recipes = _recipesConfig.Recipes;

            for (int i = 0; i < recipes.Count; i++)
            {
                if (recipes[i].UnlockAtStart)
                {
                    unlockAtStart.Add(recipes[i].Result);
                }
            }

            return new OpenedItems(unlockAtStart);
        }
    }
}