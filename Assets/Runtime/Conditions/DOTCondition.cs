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
        private float damagePerTick;
        private HealthHandler AffectedHealth;

        /// <summary>
        /// Damage per tick. Read only.
        /// </summary>
        public float DamagePerTick
        {
            get { return damagePerTick; }
        }

        /// <summary>
        /// Creates instance of DOTCondition
        /// </summary>
        /// <param name="damagePerTick">Damage per tick.</param>
        public DOTCondition(float damagePerTick)
        {
            this.damagePerTick = damagePerTick;
        }
        
        /// <summary>
        /// Instance with specific duration
        /// </summary>
        /// <param name="damagePerTick">Damage per tick.</param>
        /// <param name="duration">How long it lasts.</param>
        public DOTCondition(float damagePerTick, float duration)
        {
            this.Duration = duration;
            this.damagePerTick = damagePerTick;
        }
        
        public override void OnApplied(ConditionBank bank)
        {
            this.AffectedHealth = bank.GetComponent<HealthHandler>();
        }

        public override void OnTicked(ConditionBank bank, float deltaTime)
        {
            this.AffectedHealth.TakeDamage((int)this.damagePerTick);
        }
    }
}
