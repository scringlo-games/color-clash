using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Conditions.Unused;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ApplyAOEConditionToOtherOnCollisionEnter : ApplyConditionToOtherOnCollisionEnter
    {
        [SerializeField]
        private float radius;
        [SerializeField]
        private int damage;

        protected override Condition GetCondition()
        {
            return new AOECondition(this.duration, this.radius, this.damage, this.IsPassingFilter);
        }

        private bool IsPassingFilter(GameObject entity)
        {
            return this.filter.Evaluate(entity);
        }
    }
}
