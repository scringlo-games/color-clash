using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons.Framework.Triggers
{
    public abstract class WeaponTrigger<TContext> : MonoBehaviour, IWeaponTrigger<TContext>
    {
        public bool IsHeld { get; protected set; }
        
        public event Action<TContext> Triggered;
        
        public virtual void Pull(TContext context = default)
        {
            this.IsHeld = true;
            this.Trigger(context);
        }

        public virtual void Release(TContext context = default)
        {
            this.IsHeld = false;
            this.Trigger(context);
        }

        protected void Trigger(TContext context = default)
        {
            this.Triggered?.Invoke(context);
        }
    }
}
