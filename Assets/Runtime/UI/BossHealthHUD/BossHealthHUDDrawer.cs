using System;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.BossHealthHUD
{
    public class BossHealthHUDDrawer : MonoBehaviour, IBindable<HealthHandler>
    {
        [SerializeField]
        private GameObject boss;
        [SerializeField]
        private ProgressDrawer healthProgressDrawer;
        [SerializeField]
        private ProgressDrawer overhealProgressDrawer;
        private HealthHandler healthHandler;
        private Killable killable;
        
        public HealthHandler BoundTo { get; private set; }
        
        public void Bind(HealthHandler healthHandler)
        {
            this.BoundTo = healthHandler;
        }

        public void Unbind()
        {
            this.BoundTo = null;
        }

        private void Awake()
        {
            this.healthHandler = boss.GetComponent<HealthHandler>();
            this.killable = boss.GetComponent<Killable>();
        }

        private void OnEnable()
        {
            this.Bind(healthHandler);
            
            killable.Killed += OnBossKilled;
        }

        private void OnDisable()
        {
            killable.Killed -= OnBossKilled;
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
        
        private void OnBossKilled()
        {
            this.gameObject.SetActive(false);
        }
    }
}
