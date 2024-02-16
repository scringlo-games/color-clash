using System;
using TravisRFrench.Common.Runtime.ScriptableEvents;
using TravisRFrench.Common.Runtime.Timing;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Attacks
{
    public abstract class AttackBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Countdown cooldown;
        [SerializeField]
        private ScriptableEvent<GameObject> attackedEvent;

        public bool CanAttack { get; set; } = true;

        protected virtual void Awake()
        {
            this.cooldown.Elapsed += this.OnCooldownElapsed;
        }

        protected virtual void OnDestroy()
        {
            this.cooldown.Elapsed -= this.OnCooldownElapsed;
        }
        
        public void Attack()
        {
            if (!this.CanAttack)
            {
                return;
            }
            
            this.OnAttack();
            this.attackedEvent.Raise(this.gameObject);
            this.CanAttack = false;
            this.cooldown.Start();
        }

        private void Update()
        {
            this.cooldown.Tick(Time.deltaTime);
        }

        protected abstract void OnAttack();
        
        private void OnCooldownElapsed(ICountdown countdown)
        {
            this.CanAttack = true;
            this.cooldown.Reset();
        }
    }
}
