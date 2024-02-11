using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ApplyDOTToOtherOnCollisionEnter : ApplyConditionToOtherOnCollisionEnter
    {
        [Tooltip("The amount of periodic damage to inflict to the other object.")]
        [SerializeField]
        private int damageToInflict = 1;

        protected override Condition GetCondition()
        {
            return new TakeDamageOnTickCondition(this.duration, this.damageToInflict);
        }
    }
}
