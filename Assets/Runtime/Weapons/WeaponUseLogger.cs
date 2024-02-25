using ScringloGames.ColorClash.Runtime.Weapons.Framework;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    public class WeaponUseLogger : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;
        
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
        
        private void OnWeaponUseSucceeded(WeaponUsedArgs<WeaponContext> args)
        {
            Debug.Log($"Weapon {this.weapon} used successfully!");
        }
        
        private void OnWeaponUseFailed(WeaponUsedArgs<WeaponContext> args)
        {
            Debug.Log($"Weapon {this.weapon} used unsuccessfully! Reason: {args.Precondition}");
        }
    }
}