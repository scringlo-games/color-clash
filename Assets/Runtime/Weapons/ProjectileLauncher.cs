using ScringloGames.ColorClash.Runtime.Aiming;
using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Weapons.Framework;
using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;
using UnityEngine.Networking;
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

        [SerializeField] private bool laserOnDelay = false;
        [SerializeField] private WeaponHasLaser laser;
        /// <summary>
        /// Does this fire on delay?
        /// </summary>
        [SerializeField] private bool hasDelay = false;
        /// <summary>
        /// If this fires on delay, it lasts this long.
        /// </summary>
        [SerializeField] private float fireDelay = 0;
        private bool isDelayed = false;
        private float delayCounter = 0;
        
        private DirectionalLooker looker;
        public GameObject ObjectToLaunch
        {
            get => this.objectToLaunch;
            set => this.objectToLaunch = value;
        }

        private void OnEnable()
        {
            this.weapon.UseSucceeded += this.OnWeaponUseSucceeded;
            looker = this.GetComponentInParent<DirectionalLooker>();
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
                Instantiate(this.objectToLaunch, this.fireFrom.transform.position, this.fireFrom.transform.rotation);
            Vector2 launchSpeed = this.fireFrom.transform.up * this.launchVelocity;
            newProjectile.GetComponent<Rigidbody2D>().velocity = launchSpeed;

            if (newProjectile.TryGetComponent<DamageSource>(out var damageSource))
            {
                damageSource.Originator = this.weapon.Owner;
            }
        }

        private void Update()
        {
            // Firing delay
            if (isDelayed)
            {
                if (!laser.turnedOn)
                {
                    laser.TurnLaserOn();
                    laser.ShootLaser();
                }
                if (delayCounter < fireDelay)
                {
                    delayCounter += Time.deltaTime;
                }
                else
                {
                    this.Launch();
                    delayCounter = 0;
                    isDelayed = false;
                    laser.TurnLaserOff();
                    this.looker.UnlockRotation();
                }
            }
        }

        private void OnWeaponUseSucceeded(WeaponUsedArgs<WeaponContext> args)
        {
            if (hasDelay)
            {
                isDelayed = true;
                looker.LockRotation();
            }
            else
            {
                this.Launch(); 
            }
            
        }
    }
}
