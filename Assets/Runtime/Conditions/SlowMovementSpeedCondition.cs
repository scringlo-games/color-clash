using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class SlowMovementSpeedCondition : ModifyMovementSpeedCondition
    {
        public SlowMovementSpeedCondition(int tickDuration, float amount) 
            : base(tickDuration, new AttributeModifier()
        {
            Type = ModifierType.PercentAdditive,
            Value = -Mathf.Abs(amount),
        })
        {
        }
    }
}
