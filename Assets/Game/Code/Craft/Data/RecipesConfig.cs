using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Craft
{
    [CreateAssetMenu(menuName = "Configs/Craft/RecipesConfig", fileName = "RecipesConfig")]
    public class RecipesConfig : ScriptableObject
    {
        [field: SerializeField] public List<Recipe> Recipes { get; private set; }
    }
}