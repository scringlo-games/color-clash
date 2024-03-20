using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Damage;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class OnCollisionEnterApplyHealOriginatorFlatAmountOnDamageTakenCondition 
        : OnCollisionEnterApplyConditionToOther
    {
        [SerializeField]
        private float amount;
        [SerializeField]
        private DamageArgsEvent damagedEvent;

        protected override Condition GetCondition(Collider2D collider2D)
        {
            return new HealOriginatorForFlatAmountOnDamageTakenCondition(
                this.duration, 
                this.damagedEvent, 
                this.amount);
        }
    }
}
