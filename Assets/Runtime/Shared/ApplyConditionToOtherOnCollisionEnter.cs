using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public abstract class ApplyConditionToOtherOnCollisionEnter : MonoBehaviour
    {
        [SerializeField]
        protected float duration = 2f;
        [SerializeField]
        protected GameObjectFilterSet filter;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var other = collision.collider;

            if (!this.filter.Evaluate(other.gameObject))
            {
                return;
            }

            var conditionBank = other.GetComponent<ConditionBank>();
            
            if (conditionBank == null)
            {
                return;
            }

            var condition = this.GetCondition(collision);
            conditionBank.Apply(condition);
        }

        protected abstract Condition GetCondition(Collision2D collision);
    }
}
