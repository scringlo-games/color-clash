using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Damage;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ApplyDOTToOtherOnCollisionEnter : ApplyConditionToOtherOnCollisionEnter
    {
        [Tooltip("The amount of periodic damage to inflict to the other object.")]
        [SerializeField]
        private int damageToInflict = 1;
        [SerializeField]
        private DamageSource damageSource;

        protected override Condition GetCondition(Collision2D collision)
        {
            return new TakeDamageOnTickCondition(this.duration, this.damageSource.Originator, this.damageToInflict);
        }
    }
}
