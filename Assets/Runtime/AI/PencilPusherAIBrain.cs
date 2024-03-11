using ScringloGames.ColorClash.Runtime.Aiming;
using ScringloGames.ColorClash.Runtime.Movement;
using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public class PencilPusherAIBrain : MonoBehaviour
    {
        /*
     * The Plan:
     * Constantly aims at player
     * Constantly shooting at player
     * Cooldown comes from PaintLauncher script
     * Maybe moves? Probably not?
     */

        private GameObject target;
        [SerializeField] private DirectionalLooker looker;
        [SerializeField] private Weapon weapon;
        private AmmunitionBank ammo;
        [SerializeField]
        private DestinationMover mover;

        private bool reloadTimerOn = false;
        [SerializeField] private float reloadTime = 0.5f;
        [SerializeField] private GameObject laserFrom;
        private float reloadTimer;
        private Ray laser;

        /// <summary>
        /// Delay before shooting.
        /// </summary>
        [SerializeField] private float FireDelay = 1.0f;
        private float FireDelayTimer;
        /// <summary>
        /// Stores state of Ready to Fire.
        /// When true, the gun is locked in position.
        /// When false, the gun can aim.
        /// </summary>
        private bool ReadyToFire;
        void OnEnable()
        {
            this.target = GameObject.FindWithTag("Player");
            this.ammo = this.weapon.GetComponent<AmmunitionBank>();
            FireDelayTimer = FireDelay;
            if (this.ammo == null)
            {
                Debug.Log("Cannot find ammo bank.");
            }

            this.reloadTimer = this.reloadTime;
        }

        // Update is called once per frame
        void Update()
        {
            var targetPosition = this.target.transform.position;
            var direction = (targetPosition - this.transform.position).normalized;
            this.looker.Direction = direction;
            Debug.DrawRay(this.transform.position, this.transform.up);
            if (this.ammo.Evaluate())
            {
                this.weapon.Trigger.Pull();
            }
            else if (!this.reloadTimerOn)
            {
                this.reloadTimerOn = true;
            }

            if (this.reloadTimerOn)
            {
                if (this.reloadTimer > 0)
                {
                    this.reloadTimer -= Time.deltaTime;
                }
                else
                {
                    this.reloadTimerOn = false;
                    this.reloadTimer = this.reloadTime;
                    this.ammo.Reload();
                }
            }
        
            this.mover.MoveTo(this.target.transform.position);
        }
    }
}
