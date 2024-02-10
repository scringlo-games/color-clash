using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Mixing
{
    [CreateAssetMenu(menuName = "Scriptables/Services/Mixing Service")]
    public class MixingService : ScriptableObject
    {
        [SerializeField]
        private RecipeBook book;
        
        
    }
}
