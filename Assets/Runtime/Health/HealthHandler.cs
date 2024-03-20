using System;
using ScringloGames.ColorClash.Runtime.Damage;
using TravisRFrench.Common.Runtime.Timing;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Health
{
    public class HealthHandler : MonoBehaviour
    {
        public float Health { get; private set; }
        [field: SerializeField]
        public float MaxHealth { get; private set; } = 100;
        [SerializeField]
        private HealthRegistrar registrar;
        [SerializeField]
        private DamageArgsEvent damagedEvent;
        [SerializeField]
        private Interval interval;
        
        public bool IsInvincible { get; private set; }

        public event Action<float> HealthChanged;

        private void Awake()
        {
            this.Health = this.MaxHealth;
        }

        private void OnEnable()
        {
            this.registrar.Register(this);
            this.damagedEvent.Raised += this.OnDamaged;
            this.interval.Elapsed += this.OnIntervalElapsed;
        }

        private void OnDisable()
        {
            this.registrar.Deregister(this);
            this.damagedEvent.Raised -= this.OnDamaged;
            this.interval.Elapsed -= this.OnIntervalElapsed;
        }

        private void Update()
        {
            this.interval.Tick(Time.deltaTime);
        }

        private void TakeDamage(float amount)
        {
            //checks if health is above 0 before dealing damage.
            if (this.Health > 0f)
            {
                //subtracts the dmg amount from health, then invokes the currenHealth event, passing health.
                this.Health -= amount;
                this.HealthChanged?.Invoke(this.Health);
            }
        }
        
        public void Heal(float amount)
        {
            var changed = Mathf.Clamp(this.Health + amount, 0, this.MaxHealth*2f);
            this.Health = changed;
            this.HealthChanged?.Invoke(this.Health);
        }
        
        private void OnDamaged(DamageArgs args)
        {
            if (args.Receiver.gameObject != this.gameObject)
            {
                return;
            }

            if (this.IsInvincible)
            {
                return;
            }
            
            this.interval.Reset();
            this.interval.Start();
            this.IsInvincible = true;
            this.TakeDamage(args.Amount);
        }
        
        private void OnIntervalElapsed(IInterval interval)
        {
            this.IsInvincible = false;
        }
    }
}
