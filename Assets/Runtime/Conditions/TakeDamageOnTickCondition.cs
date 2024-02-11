using ScringloGames.ColorClash.Runtime.Damage;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    /// <summary>
    /// Applies damage every tick to the affected entity.
    /// </summary>
    public class TakeDamageOnTickCondition : Condition, IDamageSource
    {
        private readonly float amount;
        private DamageReceiver damageReceiver;
        
        public GameObject Originator { get; set; }

        /// <param name="duration">The duration of the condition in seconds.</param>
        /// <param name="originator">The originator of this damage source.</param>
        /// <param name="amount">Amount of damage to take per tick.</param>
        public TakeDamageOnTickCondition(float duration, GameObject originator, float amount)
            : base(duration)
        {
            this.Originator = originator;
            this.amount = amount;
        }

        public override void OnApplied(ConditionBank bank)
        {
            this.damageReceiver = bank.GetComponent<DamageReceiver>();
        }

        public override void OnTicked(ConditionBank bank, float deltaTime)
        {
            base.OnTicked(bank, deltaTime);
            
            this.damageReceiver.TakeDamage(this, this.amount);
        }

        public override Condition Clone()
        {
            return new TakeDamageOnTickCondition(this.Duration, this.Originator, this.amount);
        }

        
    }
}
