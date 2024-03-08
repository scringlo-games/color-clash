using System;
using ScringloGames.ColorClash.Runtime.Weapons.Framework;
using TravisRFrench.Common.Runtime.ScriptableEvents;
using TravisRFrench.Common.Runtime.Timing;
using UnityEngine;
using UnityEngine.Serialization;

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
        [SerializeField]
        private Interval reloadInterval;
        [Header("Events")]
        [SerializeField]
        private ScriptableEvent outOfAmmoEvent;
        [SerializeField]
        private ScriptableEvent reloadStartedEvent;
        [SerializeField]
        private ScriptableEvent reloadCompletedEvent;

        
        public int Count => this.count;
        public int Capacity => this.capacity;
        public bool IsReloading { get; private set; }

        private void OnEnable()
        {
            this.reloadInterval.Elapsed += this.OnReloadIntervalElapsed;
            this.weapon.UseSucceeded += this.OnWeaponUseSucceeded;
            this.weapon.UseFailed += this.OnWeaponUseFailed;
        }

        private void OnDisable()
        {
            this.reloadInterval.Elapsed -= this.OnReloadIntervalElapsed;
            this.weapon.UseSucceeded -= this.OnWeaponUseSucceeded;
            this.weapon.UseFailed -= this.OnWeaponUseFailed;
        }

        public void Reload()
        {
            this.IsReloading = true;
            this.reloadStartedEvent.Raise();
            
            this.reloadInterval.Reset();
            this.reloadInterval.Start();
        }

        public bool Evaluate()
        {
            return (this.Count > 0 && !this.IsReloading);
        }

        private void Update()
        {
            this.reloadInterval.Tick(Time.deltaTime);
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
        
        private void OnReloadIntervalElapsed(IInterval obj)
        {
            this.IsReloading = false;
            this.count = this.Capacity;
            this.reloadCompletedEvent.Raise();
        }
    }
}
