using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.UnitStatusFrame.Health
{
    [ExecuteAlways]
    public class UnitStatusFrameHealthDrawer : MonoBehaviour, IBindable<HealthHandler>
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

        private void OnDisable()
        {
            this.Unbind();
        }

        private void Update()
        {
            if (this.progressDrawer == null)
            {
                return;
            }
            
            var healthHandler = this.BoundTo;
            if (healthHandler == null)
            {
                return;
            }
            
            // We do a zero check on MaxHealth to prevent a DivideByZeroException
            this.progressDrawer.Progress = healthHandler.MaxHealth == 0f
                ? 0f
                : healthHandler.Health / healthHandler.MaxHealth;
        }
    }
}
