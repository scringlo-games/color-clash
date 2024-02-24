using ScringloGames.ColorClash.Runtime.Weapons.Framework;
using TravisRFrench.Common.Runtime.ScriptableEvents;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    public class AmmunitionBank : MonoBehaviour, IWeaponPrecondition
    {
        [SerializeField]
        private Weapon weapon;
        [Header("Ammunition")]
        [SerializeField]
        private int count = 10;
        [SerializeField]
        private int capacity = 10;
        [Header("Events")]
        [SerializeField]
        private ScriptableEvent outOfAmmoEvent;
        [SerializeField]
        private ScriptableEvent reloadEvent;
        
        public int Count => this.count;
        public int Capacity => this.capacity;

        private void OnEnable()
        {
            this.weapon.UseSucceeded += this.OnWeaponUseSucceeded;
            this.weapon.UseFailed += this.OnWeaponUseFailed;
        }
        
        private void OnDisable()
        {
            this.weapon.UseSucceeded -= this.OnWeaponUseSucceeded;
            this.weapon.UseFailed -= this.OnWeaponUseFailed;
        }

        public void Reload()
        {
            this.count = this.Capacity;
            this.reloadEvent.Raise();
        }

        public bool Evaluate()
        {
            return (this.Count > 0);
        }
        
        private void OnWeaponUseSucceeded(WeaponUsedArgs<WeaponContext> args)
        {
            this.count = Mathf.Clamp(this.Count - 1, 0, this.Capacity);
        }
        
        private void OnWeaponUseFailed(WeaponUsedArgs<WeaponContext> args)
        {
            if (args.Precondition is AmmunitionBank ammunitionBank)
            {
                if (ammunitionBank == this)
                {
                    this.outOfAmmoEvent.Raise();
                }
            }
        }
    }
}
