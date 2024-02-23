using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.PlayerHealthHUD
{
    public class PlayerHealthHUDDrawer : MonoBehaviour, IBindable<HealthHandler>
    {
        [SerializeField]
        private ProgressDrawer healthProgressDrawer;
        [SerializeField]
        private ProgressDrawer overhealProgressDrawer;
        
        public HealthHandler BoundTo { get; private set; }
        
        public void Bind(HealthHandler healthHandler)
        {
            this.BoundTo = healthHandler;
        }

        public void Unbind()
        {
            this.BoundTo = null;
        }

        private void OnEnable()
        {
            var player = GameObject.FindWithTag("Player");
            var healthHandler = player.GetComponent<HealthHandler>();
            this.Bind(healthHandler);
        }

        private void Update()
        {
            if (this.healthProgressDrawer == null)
            {
                return;
            }
            
            if (this.BoundTo == null)
            {
                return;
            }
            if(this.BoundTo.Health <= this.BoundTo.MaxHealth)
            {
                // We do a zero check on MaxHealth to prevent a DivideByZeroException
                this.healthProgressDrawer.Progress = this.BoundTo.MaxHealth == 0f
                    ? 0f
                    : this.BoundTo.Health / this.BoundTo.MaxHealth;
                this.overhealProgressDrawer.Progress = 0f;
            }
            if(this.BoundTo.Health > this.BoundTo.MaxHealth)
            {
                this.overhealProgressDrawer.Progress = (this.BoundTo.Health - this.BoundTo.MaxHealth) / this.BoundTo.MaxHealth;
                this.healthProgressDrawer.Progress = 1f;

            }

        
        }
    }
}