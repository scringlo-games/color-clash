using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class AOECondition : Condition
    {   
        private float radius = 2f;
        private bool hasCond;
        
        public override void OnApplied(ConditionBank bank)
        {
            Debug.Log($"applied condition onto: {bank.name}");
            // Sets the Duration of this condition to 2 seconds.
            bank.GetComponent<HealthHandler>().TakeDamage(15);
            this.Duration = 2f;

            // Gets the position of the object that this ConditionBank is on
            var thisPos = bank.transform.position;

            // Stores an array of Colliders within a radius of this object.
            var colliders = Physics2D.OverlapCircleAll(thisPos, this.radius);

            // Foreach loop goes through each collider found, checks for if each object has a ConditionBank component, if it does,
            //then it stores that bank in a variable, and then checks the list of conditions that the ConditionBank has.
        
            foreach (var target in colliders)
            {
                if (target.GetComponent<ConditionBank>() != null)
                {
                    this.hasCond = false;
                    var targetBank = target.GetComponent<ConditionBank>();
                    foreach (var targetCond in targetBank.Conditions)
                    {
                        // If any of the conditions on the current ConditionBank are the AOECondtion, it will skip this object
                        //and start checking the next object in the list.
                        if (targetCond is AOECondition)
                        {
                            this.hasCond = true;
                        }
                    } 
                    // If none of the conditions on the current ConditionBank are the AOECondition, this foreach loop will apply
                    // all of the conditions on THIS object onto the ConditionBank of the next object. 
                    if (!this.hasCond)
                    {
                        foreach (var thisCond in bank.Conditions)
                        {
                            float duration = thisCond.Duration;
                            Condition newCondition = null;
                            // Case uses pattern casting!
                            switch (thisCond)
                            {
                                case SlowCondition condition:
                                {
                                    newCondition = new SlowCondition(condition.SlowPercent, 
                                        condition.Duration - condition.Time);
                                    break;
                                }
                                case DOTCondition condition:
                                {
                                    newCondition = new DOTCondition(condition.DamagePerTick, 
                                        condition.Duration - condition.Time);
                                    break;
                                }
                            }
                            if (newCondition != null) {targetBank.Apply(newCondition); };
                        }
                    }
                }
            }
        }
    }
}