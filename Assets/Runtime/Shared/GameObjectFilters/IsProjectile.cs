using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters
{
    [CreateAssetMenu(menuName = "Scriptables/GameObject Filters/IsProjectile")]
    public class IsProjectile : GameObjectFilter
    {
        public override bool Evaluate(GameObject gameObject)
        {
            return gameObject.CompareTag("Projectile");
        }
    }
}
