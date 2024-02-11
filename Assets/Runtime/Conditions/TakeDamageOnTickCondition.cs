using ScringloGames.ColorClash.Runtime.Damage;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    /// <summary>
    /// Applies damage every tick to the affected entity.
    /// </summary>
    public class TakeDamageOnTickCondition : Condition
    {
        private readonly float amount;
        private readonly DamageSource damageSource;
        private DamageReceiver damageReceiver;

        /// <param name="duration">The duration of the condition in seconds.</param>
        /// <param name="amount">Amount of damage to take per tick.</param>
        public TakeDamageOnTickCondition(float duration, DamageSource source, float amount)
            : base(duration)
        {
            this.amount = amount;
            this.damageSource = source;
        }

        public override void OnApplied(ConditionBank bank)
        {
            this.damageReceiver = bank.GetComponent<DamageReceiver>();
        }

        public override void OnTicked(ConditionBank bank, float deltaTime)
        {
            base.OnTicked(bank, deltaTime);
            
            this.damageReceiver.TakeDamage(this.damageSource, this.amount);
        }

        public override Condition Clone()
        {
            return new TakeDamageOnTickCondition(this.Duration, this.damageSource, this.amount);
        }
    }
}
