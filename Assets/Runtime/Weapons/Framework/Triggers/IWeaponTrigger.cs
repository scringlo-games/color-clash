using System;

namespace ScringloGames.ColorClash.Runtime.Weapons.Framework.Triggers
{
    public interface IWeaponTrigger<TContext>
    {
        bool IsHeld { get; }
        
        event Action<TContext> Triggered; 

        void Pull(TContext context = default);
        void Release(TContext context = default);
    }
}
