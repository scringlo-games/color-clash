using System;
using ScringloGames.ColorClash.Runtime.Weapons.Framework.Triggers;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons.Framework
{
    public abstract class Weapon<TContext> : MonoBehaviour, IWeapon<TContext>
    {
        public abstract IWeaponTrigger<TContext> Trigger { get; }

        public event Action<WeaponUsedArgs<TContext>> UseSucceeded;
        public event Action<WeaponUsedArgs<TContext>> UseFailed;
        
        protected virtual void OnEnable()
        {
            this.Trigger.Triggered += this.OnTriggered;
        }

        protected virtual void OnDisable()
        {
            this.Trigger.Triggered -= this.OnTriggered;
        }

        private void OnTriggered(TContext context)
        {
            var preconditions = this.GetComponents<IWeaponPrecondition>();
            var args = new WeaponUsedArgs<TContext>()
            {
                Context = context,
            };
            
            foreach (var precondition in preconditions)
            {
                var wasSuccessful = precondition.Evaluate();
                args.Precondition = precondition;

                if (wasSuccessful)
                {
                    continue;
                }

                this.UseFailed?.Invoke(args);
                return;
            }
            
            this.UseSucceeded?.Invoke(args);
        }
    }
}
