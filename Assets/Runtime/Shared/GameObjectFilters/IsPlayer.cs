using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters
{
    [CreateAssetMenu(menuName = "Scriptables/GameObject Filters/IsPlayer")]
    public class IsPlayer : GameObjectFilter
    {
        public override bool Evaluate(GameObject gameObject)
        {
            if (gameObject == null)
            {
                return false;
            }
            
            return gameObject.CompareTag("Player");
        }
    }
}
