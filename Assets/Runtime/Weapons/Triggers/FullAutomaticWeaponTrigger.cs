using ScringloGames.ColorClash.Runtime.Weapons.Framework.Triggers;
using TravisRFrench.Common.Runtime.Timing;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons.Triggers
{
    public class FullAutomaticWeaponTrigger : FullAutomaticWeaponTrigger<WeaponContext>
    {
        [SerializeField]
        private Countdown cooldown;
        [SerializeField]
        private WeaponContext context;

        protected override WeaponContext Context
        {
            get => this.context;
        }
        protected override ICountdown Cooldown
        {
            get => this.cooldown;
        }
    }
}
