using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ApplyDOTToOtherOnCollisionEnter : ApplyConditionToOtherOnCollisionEnter
    {
        [Tooltip("The amount of periodic damage to inflict to the other object.")]
        [SerializeField]
        private int damageToInflict = 1;
        [Tooltip("The duration for which the condition should last in seconds.")]
        [SerializeField]
        private float duration = 2f;
        
        protected override Condition GetCondition()
        {
            return new DOTCondition(this.damageToInflict)
            {
                Duration = this.duration,
            };
        }
    }
}
