using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.PlayerHealthHUD
{
    public class PlayerHealthHUDDrawer : MonoBehaviour, IBindable
    {
        [SerializeField]
        private ProgressDrawer healthProgressDrawer;
        [SerializeField]
        private ProgressDrawer overhealProgressDrawer;
        private HealthHandler healthHandler;

        public GameObject BoundTo { get; private set; }
        
        public void Bind(GameObject obj)
        {
            this.BoundTo = obj;
            this.healthHandler = obj.GetComponent<HealthHandler>();
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
            if (this.healthProgressDrawer == null)
            {
                return;
            }
            
            if (this.BoundTo == null)
            {
                return;
            }
            if(this.healthHandler.Health <= this.healthHandler.MaxHealth)
            {
                // We do a zero check on MaxHealth to prevent a DivideByZeroException
                this.healthProgressDrawer.Progress = this.healthHandler.MaxHealth == 0f
                    ? 0f
                    : this.healthHandler.Health / this.healthHandler.MaxHealth;
                this.overhealProgressDrawer.Progress = 0f;
            }
            if(this.healthHandler.Health > this.healthHandler.MaxHealth)
            {
                this.overhealProgressDrawer.Progress = 
                    (this.healthHandler.Health - this.healthHandler.MaxHealth) / this.healthHandler.MaxHealth;
                this.healthProgressDrawer.Progress = 1f;

            }

        
        }
    }
}