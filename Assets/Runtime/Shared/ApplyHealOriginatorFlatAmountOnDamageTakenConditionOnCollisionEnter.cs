using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Damage;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ApplyHealOriginatorFlatAmountOnDamageTakenConditionOnCollisionEnter : ApplyConditionToOtherOnCollisionEnter
    {
        [SerializeField]
        private float amount;
        [SerializeField]
        private DamageArgsEvent damagedEvent;

        protected override Condition GetCondition(Collision2D collision)
        {
            return new HealOriginatorForFlatAmountOnDamageTakenCondition(this.duration, this.damagedEvent, this.amount);
        }
    }
}
