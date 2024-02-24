using System;
using ScringloGames.ColorClash.Runtime.Weapons.Framework.Triggers;

namespace ScringloGames.ColorClash.Runtime.Weapons.Framework
{
    public interface IWeapon<TContext>
    {
        IWeaponTrigger<TContext> Trigger { get; }

        event Action<WeaponUsedArgs<TContext>> UseSucceeded;
        event Action<WeaponUsedArgs<TContext>> UseFailed;
    }
}
