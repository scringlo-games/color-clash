using System;
using System.Linq;
using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class AOECondition : Condition
    {   
        private readonly float radius = 2f;
        private readonly int damage;
        private readonly Func<GameObject, bool> filter;
        // private bool hasCondition;
        
        // public override void OnApplied(ConditionBank bank)
        // {
        //     Debug.Log($"applied condition onto: {bank.name}");
        //     // Sets the Duration of this condition to 2 seconds.
        //     bank.GetComponent<HealthHandler>().TakeDamage(15);
        //
        //     // Gets the position of the object that this ConditionBank is on
        //     var thisPos = bank.transform.position;
        //
        //     // Stores an array of Colliders within a radius of this object.
        //     var colliders = Physics2D.OverlapCircleAll(thisPos, this.radius);
        //
        //     // Foreach loop goes through each collider found, checks for if each object has a ConditionBank component, if it does,
        //     //then it stores that bank in a variable, and then checks the list of conditions that the ConditionBank has.
        //
        //     foreach (var target in colliders)
        //     {
        //         if (target.GetComponent<ConditionBank>() != null)
        //         {
        //             this.hasCondition = false;
        //             var targetBank = target.GetComponent<ConditionBank>();
        //             foreach (var targetCond in targetBank.Conditions)
        //             {
        //                 // If any of the conditions on the current ConditionBank are the AOECondtion, it will skip this object
        //                 //and start checking the next object in the list.
        //                 if (targetCond is AOECondition)
        //                 {
        //                     this.hasCondition = true;
        //                 }
        //             } 
        //             // If none of the conditions on the current ConditionBank are the AOECondition, this foreach loop will apply
        //             // all of the conditions on THIS object onto the ConditionBank of the next object. 
        //             if (!this.hasCondition)
        //             {
        //                 foreach (var thisCond in bank.Conditions)
        //                 {
        //                     // Case uses pattern casting!
        //                     Condition newCondition = thisCond switch
        //                     {
        //                         SlowCondition condition => new SlowCondition(
        //                             condition.SlowPercent,
        //                             condition.Duration - condition.Time),
        //                         DOTCondition condition => new DOTCondition(
        //                             condition.DamagePerTick,
        //                             condition.Duration - condition.Time),
        //                         _ => null
        //                     };
        //                     if (newCondition != null) {targetBank.Apply(newCondition); };
        //                 }
        //             }
        //         }
        //     }
        // }

        public AOECondition(float duration, float radius, int damage, Func<GameObject, bool> filter)
            : base(duration)
        {
            this.radius = radius;
            this.damage = damage;
            this.filter = filter;
        }

        public override void OnApplied(ConditionBank bank)
        {
            if (bank == null)
            {
                return;
            }

            if (bank.TryGetComponent(out HealthHandler healthHandler))
            {
                healthHandler.TakeDamage(this.damage);
            }

            var position = bank.transform.position;
            var collidersInRadius = Physics2D.OverlapCircleAll(position, this.radius);
            var gameObjectsToAffect = collidersInRadius
                .Where(collider => this.filter.Invoke(collider.gameObject))
                .Select(collider => collider.gameObject);

            foreach (var gameObject in gameObjectsToAffect)
            {
                // If it doesn't have a condition bank, skip it
                if (!gameObject.TryGetComponent(out ConditionBank otherBank))
                {
                    continue;
                }

                var otherConditions = otherBank.Conditions;
                
                // If it has an AOECondition, we skip it to prevent an infinite loop
                if (otherConditions.Any(condition => condition is AOECondition))
                {
                    continue;
                }
                
                // Clone all the conditions from this bank and apply them to the other bank
                var clonedConditions = bank.Conditions
                    .Select(condition => condition.Clone());

                foreach (var condition in clonedConditions)
                {
                    otherBank.Apply(condition);
                }
            }
        }

        public override Condition Clone()
        {
            return new AOECondition(this.Duration, this.radius, this.damage, this.filter);
        }
    }
}
