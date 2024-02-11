using ScringloGames.ColorClash.Runtime.Health;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    /// <summary>
    /// Applies damage every tick to the affected entity.
    /// </summary>
    public class TakeDamageOnTickCondition : Condition
    {
        private readonly float amount;
        private HealthHandler healthHandler;
        
        /// <param name="duration">The duration of the condition in seconds.</param>
        /// <param name="amount">Amount of damage to take per tick.</param>
        public TakeDamageOnTickCondition(float duration, float amount)
            : base(duration)
        {
            this.amount = amount;
        }

        public override void OnApplied(ConditionBank bank)
        {
            this.healthHandler = bank.GetComponent<HealthHandler>();
        }

        public override void OnTicked(ConditionBank bank, float deltaTime)
        {
            base.OnTicked(bank, deltaTime);
            
            this.healthHandler.TakeDamage((int)this.amount);
        }

        public override Condition Clone()
        {
            return new TakeDamageOnTickCondition(this.Duration, this.amount);
        }
    }
}
