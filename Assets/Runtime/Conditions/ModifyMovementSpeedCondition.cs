using ScringloGames.ColorClash.Runtime.Shared.Attributes;
using TravisRFrench.Attributes.Runtime;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class ModifyMovementSpeedCondition : Condition
    {
        private readonly AttributeModifier modifier;
        private AttributeBank attributeBank;

        public ModifyMovementSpeedCondition(float duration, AttributeModifier modifier) : base(duration)
        {
            this.modifier = modifier;
        }

        public override void OnApplied(ConditionBank bank)
        {
            base.OnApplied(bank);
            
            this.attributeBank = bank.GetComponent<AttributeBank>();

            if (this.attributeBank == null)
            {
                return;
            }
            
            this.attributeBank.MovementSpeedMultiplier.AddModifier(this.modifier);
            this.attributeBank.MovementSpeedMultiplier.ForceRecalculateModifiedValue();
        }

        public override void OnExpired(ConditionBank bank)
        {
            base.OnExpired(bank);

            this.attributeBank.MovementSpeedMultiplier.RemoveModifier(this.modifier);
            this.attributeBank.MovementSpeedMultiplier.ForceRecalculateModifiedValue();
        }

        public override Condition Clone()
        {
            return new ModifyMovementSpeedCondition(this.Duration, this.modifier);
        }
    }
}
