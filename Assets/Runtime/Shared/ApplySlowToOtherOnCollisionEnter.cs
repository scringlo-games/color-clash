using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ApplySlowToOtherOnCollisionEnter : ApplyConditionToOtherOnCollisionEnter
    {
        [FormerlySerializedAs("slowPercent")]
        [Tooltip("The amount by which the other object should be slowed.")]
        [SerializeField]
        private float amount = 1f;

        protected override Condition GetCondition(Collision2D collision)
        {
            return new SlowMovementSpeedCondition(this.duration, this.amount);
        }
    }
}
