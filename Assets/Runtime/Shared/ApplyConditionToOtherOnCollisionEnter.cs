using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public abstract class ApplyConditionToOtherOnCollisionEnter : MonoBehaviour
    {
        [SerializeField]
        private GameObjectFilterSet filter;
        
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

            var condition = this.GetCondition();
            conditionBank.Apply(condition);
        }

        protected abstract Condition GetCondition();
    }
}
