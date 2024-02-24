using TravisRFrench.Common.Runtime.Timing;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons.Framework.Triggers
{
    public abstract class FullAutomaticWeaponTrigger<TContext> : WeaponTrigger<TContext>
    {
        protected abstract TContext Context { get; }
        protected virtual bool IsReady { get; set; } = true;
        protected abstract ICountdown Cooldown { get; }
        
        public override void Pull(TContext context = default)
        {
            this.IsHeld = true;
        }

        public override void Release(TContext context = default)
        {
            this.IsHeld = false;
        }

        protected virtual void OnEnable()
        {
            this.Cooldown.Elapsed += this.OnCountdownElapsed;
        }

        protected virtual void OnDisable()
        {
            this.Cooldown.Elapsed -= this.OnCountdownElapsed;
        }

        protected virtual void Update()
        {
            if (this.IsHeld && this.IsReady)
            {
                this.Trigger(this.Context);
                this.IsReady = false;
                
                this.Cooldown.Reset();
                this.Cooldown.Start();
            }
            
            this.Cooldown.Tick(Time.deltaTime);
        }

        private void OnCountdownElapsed(ICountdown countdown)
        {
            this.IsReady = true;
        }
    }
}
