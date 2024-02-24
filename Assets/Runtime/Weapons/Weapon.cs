using ScringloGames.ColorClash.Runtime.Weapons.Framework;
using ScringloGames.ColorClash.Runtime.Weapons.Framework.Triggers;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    public class Weapon : Weapon<WeaponContext>
    {
        [SerializeField]
        private GameObject owner;
        private IWeaponTrigger<WeaponContext> trigger;

        public GameObject Owner
        {
            get => this.owner;
            set => this.owner = value;
        }
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
