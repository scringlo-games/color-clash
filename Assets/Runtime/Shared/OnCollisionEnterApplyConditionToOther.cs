using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Shared.Contact;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public abstract class OnCollisionEnterApplyConditionToOther : ContactBehaviour
    {
        [SerializeField]
        protected int duration = 2;
        [SerializeField]
        protected GameObjectFilterSet filter;

        public override void OnCollisionEntered(Collision2D collision2D)
        {
            var other = collision2D.collider;

            if (!this.filter.Evaluate(other.gameObject))
            {
                return;
            }

            var conditionBank = other.GetComponent<ConditionBank>();
            
            if (conditionBank == null)
            {
                return;
            }

            var condition = this.GetCondition(collision2D);
            conditionBank.Apply(condition);
        }

        protected abstract Condition GetCondition(Collision2D collision);
    }
}
