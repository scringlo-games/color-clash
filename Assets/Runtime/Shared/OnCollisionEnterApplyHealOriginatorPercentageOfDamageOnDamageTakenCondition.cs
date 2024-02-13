using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Damage;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class OnCollisionEnterApplyHealOriginatorPercentageOfDamageOnDamageTakenCondition : OnCollisionEnterApplyConditionToOther
    {
        [SerializeField]
        private float percentage;
        [SerializeField]
        private DamageArgsEvent damagedEvent;

        protected override Condition GetCondition(Collision2D collision)
        {
            return new HealOriginatorForFlatAmountOnDamageTakenCondition(this.duration, this.damagedEvent, this.percentage);
        }
    }
}
