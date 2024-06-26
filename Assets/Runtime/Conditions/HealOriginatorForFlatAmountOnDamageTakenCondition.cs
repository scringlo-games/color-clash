﻿using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Health;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class HealOriginatorForFlatAmountOnDamageTakenCondition : Condition
    {
        private readonly DamageArgsEvent damagedEvent;
        private readonly float amount;
        private DamageReceiver damageReceiver;
        private HealthHandler healthHandler;

        public HealOriginatorForFlatAmountOnDamageTakenCondition(int tickDuration, DamageArgsEvent damagedEvent, float amount) 
            : base(tickDuration)
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
            return new HealOriginatorForFlatAmountOnDamageTakenCondition(this.TickDuration, this.damagedEvent, this.amount);
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
            
            this.healthHandler.Heal(this.amount);
        }
    }
}
