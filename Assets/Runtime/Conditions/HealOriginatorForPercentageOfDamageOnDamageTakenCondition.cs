using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Health;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class HealOriginatorForPercentageOfDamageOnDamageTakenCondition : Condition
    {
        private readonly DamageArgsEvent damagedEvent;
        private readonly float percentage;
        private DamageReceiver damageReceiver;
        private HealthHandler healthHandler;

        public HealOriginatorForPercentageOfDamageOnDamageTakenCondition(float duration, DamageArgsEvent damagedEvent, float percentage)  : base(duration)
        {
            this.damagedEvent = damagedEvent;
            this.percentage = percentage;
        }

        public override void OnApplied(ConditionBank bank)
        {
            base.OnApplied(bank);

            this.damageReceiver = bank.GetComponent<DamageReceiver>();
            
            this.damagedEvent.Raised += this.OnDamaged;
        }

        public override void OnExpired(ConditionBank bank)
        {
            base.OnExpired(bank);
            
            this.damagedEvent.Raised -= this.OnDamaged;
        }

        public override Condition Clone()
        {
            return new HealOriginatorForFlatAmountOnDamageTakenCondition(this.Duration, this.damagedEvent, this.percentage);
        }
        
        private void OnDamaged(DamageArgs args)
        {
            if (args.Receiver != this.damageReceiver)
            {
                return;
            }

            if (this.healthHandler == null)
            {
                this.healthHandler = args.Originator.GetComponent<HealthHandler>();
            }
            else
            {
                var damage = args.Amount;
                this.healthHandler.Heal(damage * this.percentage);
            }
        }
    }
}
