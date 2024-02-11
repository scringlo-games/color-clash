using System;
using System.Linq;
using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class AOECondition : Condition
    {   
        private readonly float radius = 2f;
        private readonly int damage;
        private readonly Func<GameObject, bool> filter;

        public AOECondition(float duration, float radius, int damage, Func<GameObject, bool> filter)
            : base(duration)
        {
            this.radius = radius;
            this.damage = damage;
            this.filter = filter;
        }

        public override void OnApplied(ConditionBank bank)
        {
            if (bank == null)
            {
                return;
            }

            if (bank.TryGetComponent(out HealthHandler healthHandler))
            {
                healthHandler.TakeDamage(this.damage);
            }

            var position = bank.transform.position;
            var collidersInRadius = Physics2D.OverlapCircleAll(position, this.radius);
            var gameObjectsToAffect = collidersInRadius
                .Where(collider => this.filter.Invoke(collider.gameObject))
                .Select(collider => collider.gameObject);

            foreach (var gameObject in gameObjectsToAffect)
            {
                // If it doesn't have a condition bank, skip it
                if (!gameObject.TryGetComponent(out ConditionBank otherBank))
                {
                    continue;
                }

                var otherConditions = otherBank.Conditions;
                
                // If it has an AOECondition, we skip it to prevent an infinite loop
                if (otherConditions.Any(condition => condition is AOECondition))
                {
                    continue;
                }
                
                // Clone all the conditions from this bank and apply them to the other bank
                var clonedConditions = bank.Conditions
                    .Select(condition => condition.Clone());

                foreach (var condition in clonedConditions)
                {
                    otherBank.Apply(condition);
                }
            }
        }

        public override Condition Clone()
        {
            return new AOECondition(this.Duration, this.radius, this.damage, this.filter);
        }
    }
}
