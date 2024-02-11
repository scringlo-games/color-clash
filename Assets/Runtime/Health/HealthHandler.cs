using System;
using ScringloGames.ColorClash.Runtime.Damage;
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
        private DamagedEvent damagedEvent;

        public event Action<float> HealthChanged;

        private void Awake()
        {
            this.Health = this.MaxHealth;
        }

        private void OnEnable()
        {
            this.registrar.Register(this);
            this.damagedEvent.Raised += this.OnDamaged;
        }

        private void OnDisable()
        {
            this.registrar.Deregister(this);
            this.damagedEvent.Raised -= this.OnDamaged;
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

        private void Heal(float amount)
        {
            //adds health to the health variable
            this.Health += amount;
            this.HealthChanged?.Invoke(this.Health);
        }
        
        private void OnDamaged(DamageArgs args)
        {
            if (args.Receiver.gameObject != this.gameObject)
            {
                return;
            }
            
            this.TakeDamage(args.Amount);
        }
    }
}
