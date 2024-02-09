using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    public class SlowProjectile : ProjectileHitScript
    {
        [SerializeField] private float slowPercent = 0.6f;
        [SerializeField] private float duration = 2;
        [SerializeField] private int hitDamage = 1;
        protected override void ApplyProjectileEffects(GameObject otherGameObject)
        {
            if (this.gameObject.TryGetComponent(out ApplySlowCondition condition))
            {
                condition.ApplyTo(otherGameObject, this.slowPercent, this.duration);
            }

            if (otherGameObject.GetComponent<ProjectileHitScript>() != null)
            {
                Destroy(this.gameObject);
            }
        }

        protected override void IfHasHealth(GameObject otherGameObject)
        {
            if (otherGameObject.TryGetComponent(out HealthHandler healthHandler))
            {
                healthHandler.TakeDamage(this.hitDamage);
            }
        }
    }
}
