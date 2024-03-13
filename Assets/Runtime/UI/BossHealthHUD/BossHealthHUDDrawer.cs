using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.BossHealthHUD
{
    public class BossHealthHUDDrawer : MonoBehaviour, IBindable<HealthHandler>
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
            // By virtue of bosses being the first enemy in a boss room, this should be effective without requiring
            // more super niche code.
            // For the record - I hate this.
            var boss = GameObject.FindWithTag("Enemy");
            var healthHandler = boss.GetComponent<HealthHandler>();
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
