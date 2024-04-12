using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.UnitStatusFrame.Health
{
    [ExecuteAlways]
    public class UnitStatusFrameHealthDrawer : MonoBehaviour, IBindable
    {
        [SerializeField]
        private ProgressDrawer progressDrawer;
        [SerializeField]
        private RectTransform healthObj;
        private HealthHandler healthHandler;
        public GameObject BoundTo { get; private set; }
        
        public void Bind(GameObject obj)
        {
            this.BoundTo = obj;
            this.healthHandler = obj.GetComponent<HealthHandler>();
            
            this.healthObj.sizeDelta = new Vector2(healthHandler.MaxHealth, this.healthObj.sizeDelta.y);
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
