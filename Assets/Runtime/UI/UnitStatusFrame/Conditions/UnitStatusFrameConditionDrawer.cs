using System.Linq;
using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.UnitStatusFrame.Conditions
{
    public class UnitStatusFrameConditionDrawer : MonoBehaviour, IBindable
    {
        [Header("Drawers")]
        [SerializeField]
        private UnitStatusFrameConditionElementDrawer damageOverTimeElement;
        [SerializeField]
        private UnitStatusFrameConditionElementDrawer healElement;
        [SerializeField]
        private UnitStatusFrameConditionElementDrawer slowElement;
        [Header("Events")]
        [SerializeField]
        private ConditionAppliedOrExpiredEvent conditionAppliedEvent;
        [SerializeField]
        private ConditionAppliedOrExpiredEvent conditionExpiredEvent;
        private ConditionBank conditionBank;
        
        public GameObject BoundTo { get; private set; }

        public void Bind(GameObject obj)
        {
            this.BoundTo = obj;
            this.conditionBank = obj.GetComponent<ConditionBank>();
        }

        public void Unbind()
        {
            this.BoundTo = null;
        }

        private void OnEnable()
        {
            this.conditionAppliedEvent.Raised += this.OnConditionApplied;
            this.conditionExpiredEvent.Raised += this.OnConditionExpired;
        }
        
        private void OnDisable()
        {
            this.conditionAppliedEvent.Raised -= this.OnConditionApplied;
            this.conditionExpiredEvent.Raised -= this.OnConditionExpired;
        }

        private void UpdateConditionElements()
        {
            if (this.conditionBank == null)
            {
                return;
            }
            
            /* Get Condition Stack Count */
            var damageOverTimeConditionCount = this.conditionBank.Conditions
                .Count(condition => condition is TakeDamageOnTickCondition);
            var healConditionCount = this.conditionBank.Conditions
                .Count(condition => condition is
                    HealOriginatorForFlatAmountOnDamageTakenCondition or
                    HealOriginatorForPercentageOfDamageOnDamageTakenCondition);
            var slowConditionCount = this.conditionBank.Conditions
                .Count(condition => condition is SlowMovementSpeedCondition);
            
            /* Update Condition Visibility */
            var hasDamageOverTimeCondition = damageOverTimeConditionCount > 0;
            var hasHealCondition = healConditionCount > 0;
            var hasSlowCondition = slowConditionCount > 0;

            this.damageOverTimeElement.gameObject.SetActive(hasDamageOverTimeCondition);
            this.healElement.gameObject.SetActive(hasHealCondition);
            this.slowElement.gameObject.SetActive(hasSlowCondition);
            
            /* Update Condition Stack Count */
            if (hasDamageOverTimeCondition)
            {
                this.damageOverTimeElement.StackCount = damageOverTimeConditionCount;
            }

            if (hasHealCondition)
            {
                this.healElement.StackCount = healConditionCount;
            }

            if (hasSlowCondition)
            {
                this.slowElement.StackCount = slowConditionCount;
            }
        }

        private void OnConditionApplied(ConditionAppliedOrExpiredEvent.ConditionAppliedOrExpiredEventArgs args)
        {
            if (args.ConditionBank != this.conditionBank)
            {
                return;
            }
            
            this.UpdateConditionElements();
        }

        private void OnConditionExpired(ConditionAppliedOrExpiredEvent.ConditionAppliedOrExpiredEventArgs args)
        {
            if (args.ConditionBank != this.conditionBank)
            {
                return;
            }
            
            this.UpdateConditionElements();
        }
    }
}
