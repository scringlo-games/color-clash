using System.Collections;
using ScringloGames.ColorClash.Runtime.Weapons.Framework;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    public class OnWeaponSuccessEnableHitBox : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;
        [SerializeField]
        private GameObject hitBox;
        [SerializeField]
        private float duration = 1f;
        
        private void OnEnable()
        {
            this.weapon.UseSucceeded += this.OnWeaponUseSucceeded;
        }

        private void OnDisable()
        {
            this.weapon.UseSucceeded -= this.OnWeaponUseSucceeded;
        }

        private IEnumerator DisableHitBoxAfterDuration()
        {
            yield return new WaitForSeconds(this.duration);
            this.hitBox.SetActive(false);
        }

        private void OnWeaponUseSucceeded(WeaponUsedArgs<WeaponContext> args)
        {
            this.hitBox.SetActive(true);
            this.StartCoroutine(this.DisableHitBoxAfterDuration());
        }
    }
}
