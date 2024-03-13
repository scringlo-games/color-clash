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
            this.ApplyConditionToCollider(collision2D.collider);
        }

        public override void OnTriggerEntered(Collider2D collider2D)
        {
            this.ApplyConditionToCollider(collider2D);
        }

        private void ApplyConditionToCollider(Collider2D collider2D)
        {
            var other = collider2D;

            if (!this.filter.Evaluate(other.gameObject))
            {
                return;
            }

            var conditionBank = other.GetComponent<ConditionBank>();
            
            if (conditionBank == null)
            {
                return;
            }

            var condition = this.GetCondition(other);
            conditionBank.Apply(condition);
        }

        protected abstract Condition GetCondition(Collider2D collider2D);
    }
}
