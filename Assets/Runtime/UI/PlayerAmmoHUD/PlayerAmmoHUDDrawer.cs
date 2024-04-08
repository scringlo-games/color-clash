using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.PlayerAmmoHUD
{
    public class PlayerAmmoHUDDrawer : MonoBehaviour, IBindable
    {
        [SerializeField]
        private ProgressDrawer progressDrawer;
        private AmmunitionBank ammunitionBank;
        public GameObject BoundTo { get; private set; }
        
        public void Bind(GameObject obj)
        {
            this.BoundTo = obj;
            
            // NOTE: We WILL have to fix this once we add other weapons that have ammunition - this is just to get us
            // up and running very quickly
            this.ammunitionBank = obj.GetComponentInChildren<AmmunitionBank>();
        }

        public void Unbind()
        {
            this.BoundTo = null;
        }

        private void OnEnable()
        {
            var player = GameObject.FindWithTag("Player");
            this.Bind(player);
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
            this.progressDrawer.Progress = (this.ammunitionBank.Capacity == 0)
                ? 0f
                : (float)this.ammunitionBank.Count / (float)this.ammunitionBank.Capacity;
        }
    }
}
