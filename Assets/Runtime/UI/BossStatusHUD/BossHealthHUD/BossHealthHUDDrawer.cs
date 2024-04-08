using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.BossHealthHUD
{
    public class BossHealthHUDDrawer : MonoBehaviour, IBindable
    {
        [SerializeField]
        private GameObject boss;
        [SerializeField]
        private ProgressDrawer healthProgressDrawer;
        [SerializeField]
        private ProgressDrawer overhealProgressDrawer;
        private HealthHandler healthHandler;
        private Killable killable;
        
        public GameObject BoundTo { get; private set; }
        
        public void Bind(GameObject obj)
        {
            this.healthHandler = obj.GetComponent<HealthHandler>();
            this.killable = obj.GetComponent<Killable>();
            this.BoundTo = obj;
        }

        public void Unbind()
        {
            this.BoundTo = null;
        }

        private void Awake()
        {
            this.Bind(boss);
        }

        private void OnEnable()
        {
            this.Bind(healthHandler.gameObject);
            
            killable.Killed += OnKilled;
        }

        private void OnDisable()
        {
            killable.Killed -= OnKilled;
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
        
        private void OnKilled(Killable killable)
        {
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
