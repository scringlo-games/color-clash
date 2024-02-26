using System;
using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.PlayerAmmoHUD
{
    public class PlayerAmmoHUDDrawer : MonoBehaviour, IBindable<AmmunitionBank>
    {
        [SerializeField]
        private ProgressDrawer progressDrawer;
        public AmmunitionBank BoundTo { get; private set; }
        
        public void Bind(AmmunitionBank bank)
        {
            this.BoundTo = bank;
        }

        public void Unbind()
        {
            this.BoundTo = null;
        }

        private void OnEnable()
        {
            var player = GameObject.FindWithTag("Player");
            // NOTE: We WILL have to fix this once we add other weapons that have ammunition - this is just to get us
            // up and running very quickly
            var ammunitionBank = player.GetComponentInChildren<AmmunitionBank>();
            this.Bind(ammunitionBank);
        }

        private void Update()
        {
            if (this.progressDrawer == null)
            {
                return;
            }
            
            if (this.BoundTo == null)
            {
                return;
            }
            
            // We do a zero check on MaxHealth to prevent a DivideByZeroException
            this.progressDrawer.Progress = (this.BoundTo.Capacity == 0)
                ? 0f
                : (float)this.BoundTo.Count / (float)this.BoundTo.Capacity;
        }
    }
}
