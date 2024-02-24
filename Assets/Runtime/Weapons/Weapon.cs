using ScringloGames.ColorClash.Runtime.Weapons.Framework;
using ScringloGames.ColorClash.Runtime.Weapons.Framework.Triggers;

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    public class Weapon : Weapon<WeaponContext>
    {
        private IWeaponTrigger<WeaponContext> trigger;

        public override IWeaponTrigger<WeaponContext> Trigger => this.trigger;

        private void Awake()
        {
            this.GetDependencies();
        }

        private void Reset()
        {
            this.GetDependencies();
        }

        private void GetDependencies()
        {
            this.trigger ??= this.GetComponent<IWeaponTrigger<WeaponContext>>();
        }
    }
}
