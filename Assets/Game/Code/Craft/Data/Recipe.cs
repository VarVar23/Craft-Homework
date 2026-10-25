using System;
using System.Collections.Generic;

namespace Gameplay.Craft
{
    [Serializable]
    public class Recipe
    {
        public string Result;
        public bool UnlockAtStart;
        public List<string> NeedItems;
    }
}