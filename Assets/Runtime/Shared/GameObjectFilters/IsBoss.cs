using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters
{
    [CreateAssetMenu(menuName = "Scriptables/GameObject Filters/IsBoss")]
    public class IsBoss : GameObjectFilter
    {
        public override bool Evaluate(GameObject gameObject)
        {
            return gameObject.name.ToLower().Contains("boss");
        }
    }
}
