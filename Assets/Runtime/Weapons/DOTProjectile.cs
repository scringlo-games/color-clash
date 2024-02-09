using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    /// <summary>
    /// Makes self deal Damage
    /// Requires ApplyDOTCondition.
    /// </summary>
    public class DOTProjectile : ProjectileHitScript
    {
        [SerializeField] private float conditionDamage = 1;
        [SerializeField] private int hitDamage = 1;
        [SerializeField] private float duration = 2.0f;
        
        protected override void ApplyProjectileEffects(GameObject otherGameObject)
        {
            this.ApplyTo(otherGameObject, this.conditionDamage, this.duration);
            
            // We don't want projectiles destroying projectiles, if they can collide.
            if (otherGameObject.GetComponent<ProjectileHitScript>() == null)
            {
                Destroy(this.gameObject);
            }
        }

        protected override void IfHasHealth(GameObject otherGameObject)
        {
            otherGameObject.GetComponent<HealthHandler>().TakeDamage(this.hitDamage);
        }
        
        /// <summary>
        /// If object has a bank, applies DOT.
        /// </summary>
        /// <param name="obj">The object that receives condition</param>
        public void ApplyTo(GameObject obj, float damage, float duration)
        {
            if (obj.TryGetComponent<ConditionBank>(out var bank))
            {
                var condition = new DOTCondition(damage)
                {
                    Duration = duration,
                };
                bank.Apply(condition);
            }
        }
    }
}
