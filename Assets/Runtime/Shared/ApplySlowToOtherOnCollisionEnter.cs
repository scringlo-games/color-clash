using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ApplySlowToOtherOnCollisionEnter : ApplyConditionToOtherOnCollisionEnter
    {
        [Tooltip("The percentage by which the other object should be slowed.")]
        [Range(0f, 1f)]
        [SerializeField]
        private float slowPercent = 1f;
        [Tooltip("The duration for which the condition should last in seconds.")]
        [SerializeField]
        private float duration = 2f;
        
        protected override Condition GetCondition()
        {
            return new SlowCondition(this.slowPercent)
            {
                Duration = this.duration,
            };
        }
    }
}
