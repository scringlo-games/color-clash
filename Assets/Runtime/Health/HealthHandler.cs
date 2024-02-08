using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Health
{
    public class HealthHandler : MonoBehaviour
    {
        public int Health { get; private set; }
        [field: SerializeField]
        public int MaxHealth { get; private set; } = 100;
        [SerializeField]
        private HealthRegistrar registrar;
        public event Action<int> HealthChanged;

        private void Awake()
        {
            this.registrar.Setup();
        }

        private void Start()
        {
            //sets health to max health on the first frame of the player existing. 
            this.Health = this.MaxHealth;
        }

        private void OnEnable()
        {
            this.registrar.Register(this);
        }

        private void OnDisable()
        {
            this.registrar.Deregister(this);
        }

        public void TakeDamage(int amount)
        {
            //checks if health is above 0 before dealing damage.
            if (this.Health > 0)
            {
                //subtracts the dmg amount from health, then invokes the currenHealth event, passing health.
                this.Health -= amount;
                this.HealthChanged?.Invoke(this.Health);
            }
        }

        public void Heal(int amount)
        {
            //adds health to the health variable
            this.Health += amount;
            this.HealthChanged?.Invoke(this.Health);
        }
    }
}
