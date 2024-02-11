using System.Collections.Generic;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Mixing
{
    [CreateAssetMenu(menuName = "Scriptables/Recipe Book")]
    public class RecipeBook : ScriptableObject
    {
        [SerializeField]
        private List<Recipe> recipes;

        public IEnumerable<Recipe> Recipes => this.recipes;
    }
}
