using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class SlowMovementSpeedCondition : ModifyMovementSpeedCondition
    {
        public SlowMovementSpeedCondition(float duration, float amount) 
            : base(duration, new AttributeModifier()
        {
            Type = ModifierType.PercentAdditive,
            Value = -Mathf.Abs(amount),
        })
        {
        }
    }
}
