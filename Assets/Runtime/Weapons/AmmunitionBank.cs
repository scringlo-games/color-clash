using ScringloGames.ColorClash.Runtime.Weapons.Framework;
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

        private void OnEnable()
        {
            this.weapon.UseSucceeded += this.OnWeaponUseSucceeded;
        }

        private void OnDisable()
        {
            this.weapon.UseSucceeded -= this.OnWeaponUseSucceeded;
        }

        public void Reload()
        {
            this.count = this.capacity;
        }

        public bool Evaluate()
        {
            return (this.count > 0);
        }
        
        private void OnWeaponUseSucceeded(WeaponUsedArgs<WeaponContext> args)
        {
            this.count = Mathf.Clamp(this.count - 1, 0, this.capacity);
        }
    }
}
