using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Health;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class HealOriginatorOnDamageTakenCondition : Condition
    {
        private readonly DamageArgsEvent damagedEvent;
        private readonly float amount;
        private DamageReceiver damageReceiver;
        private HealthHandler healthHandler;

        public HealOriginatorOnDamageTakenCondition(float duration, DamageArgsEvent damagedEvent, float amount)  : base(duration)
        {
            this.damagedEvent = damagedEvent;
            this.amount = amount;
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
            return new HealOriginatorOnDamageTakenCondition(this.Duration, this.damagedEvent, this.amount);
        }
        
        private void OnDamaged(DamageArgs args)
        {
            if (args.Receiver != this.damageReceiver)
            {
                return;
            }

            args.Originator.TryGetComponent(out this.healthHandler);

            if (this.healthHandler == null)
            {
                return;
            }
            
            this.healthHandler.Heal(this.amount);
        }
    }
}
