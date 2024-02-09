using ScringloGames.ColorClash.Runtime.Health;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    /// <summary>
    /// Applies Damage Over Time to affected object.
    /// </summary>
    public class DOTCondition : Condition
    {
        /// <summary>
        /// Damage dealt per tick
        /// </summary>
        private readonly float damagePerTick;
        private HealthHandler affectedHealth;
        
        /// <param name="duration">The duration of the condition in seconds.</param>
        /// <param name="damagePerTick">Damage per tick.</param>
        public DOTCondition(float duration, float damagePerTick)
            : base(duration)
        {
            this.damagePerTick = damagePerTick;
        }

        public override void OnApplied(ConditionBank bank)
        {
            this.affectedHealth = bank.GetComponent<HealthHandler>();
        }

        public override void OnTicked(ConditionBank bank, float deltaTime)
        {
            // We need to ensure that the OnTicked() method of the base class gets updated so that Time is incremented
            base.OnTicked(bank, deltaTime);
            
            this.affectedHealth.TakeDamage((int)this.damagePerTick);
        }

        public override Condition Clone()
        {
            return new DOTCondition(this.damagePerTick, this.Duration);
        }
    }
}
