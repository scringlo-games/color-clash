using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.PlayerHealthHUD
{
    public class PlayerHealthHUDDrawer : MonoBehaviour, IBindable<HealthHandler>
    {
        [SerializeField]
        private ProgressDrawer progressDrawer;
        
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
            if (this.progressDrawer == null)
            {
                return;
            }
            
            if (this.BoundTo == null)
            {
                return;
            }
            
            // We do a zero check on MaxHealth to prevent a DivideByZeroException
            this.progressDrawer.Progress = this.BoundTo.MaxHealth == 0f
                ? 0f
                : this.BoundTo.Health / this.BoundTo.MaxHealth;
        }
    }
}