using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Weapons.Framework;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    /// <summary>
    /// Fires given object, with a public velocity, distance from origin and cooldown, up.
    /// </summary>
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;
        [SerializeField]
        private float launchVelocity = 1.0f;
        [SerializeField]
        private float pitchVariation = 0.5f;
        [SerializeField]
        private GameObject objectToLaunch;
        [SerializeField]
        private GameObject fireFrom;

        public GameObject ObjectToLaunch
        {
            get => this.objectToLaunch;
            set => this.objectToLaunch = value;
        }

        private void OnEnable()
        {
            this.weapon.UseSucceeded += this.OnWeaponUseSucceeded;
        }

        private void OnDisable()
        {
            this.weapon.UseSucceeded -= this.OnWeaponUseSucceeded;
        }

        private void Launch()
        {
            if (this.TryGetComponent(out AudioSource audioSource))
            {
                audioSource.pitch = (this.pitchVariation * Random.value) + 1.0f;
                audioSource.Play();
            }
            var newProjectile = 
                Instantiate(this.objectToLaunch, this.fireFrom.transform.position, this.transform.rotation);
            Vector2 launchSpeed = this.transform.up * this.launchVelocity;
            newProjectile.GetComponent<Rigidbody2D>().velocity = launchSpeed;

            if (newProjectile.TryGetComponent<DamageSource>(out var damageSource))
            {
                damageSource.Originator = this.weapon.Owner;
            }
        }

        private void OnWeaponUseSucceeded(WeaponUsedArgs<WeaponContext> args)
        {
            this.Launch();
        }
    }
}
