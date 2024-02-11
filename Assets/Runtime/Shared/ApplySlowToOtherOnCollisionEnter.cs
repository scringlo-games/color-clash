using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Conditions.Unused;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ApplySlowToOtherOnCollisionEnter : ApplyConditionToOtherOnCollisionEnter
    {
        [Tooltip("The percentage by which the other object should be slowed.")]
        [Range(0f, 1f)]
        [SerializeField]
        private float slowPercent = 1f;

        protected override Condition GetCondition()
        {
            return new SlowCondition(this.duration, this.slowPercent);
        }
    }
}
