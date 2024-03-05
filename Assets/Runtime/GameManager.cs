using System.Collections.Generic;
using System.Linq;
using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.GameServices;
using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class GameManager : MonoBehaviour
    {
        [Header("Registrars")]
        [SerializeField]
        private HealthRegistrar healthRegistrar;
        [SerializeField]
        private ConditionBankRegistrar conditionBankRegistrar;
        [Header("Services")]
        [SerializeField]
        private List<GameService> services;
        

        public IEnumerable<GameService> Services => this.services;

        private void Awake()
        {
            #region REGISTRARS
            
            this.healthRegistrar.Setup();
            this.conditionBankRegistrar.Setup();
            
            #endregion
            
            #region SERVICES
            
            foreach (var service in this.GetValidServices())
            {
                service.Setup();
            }
            
            #endregion
        }

        private void Update()
        {
            #region SERVICES
            
            foreach (var service in this.GetValidServices())
            {
                service.Tick(Time.deltaTime);
            }
            
            #endregion
        }

        private void OnDestroy()
        {
            foreach (var service in this.GetValidServices())
            {
                service.Teardown();
            }
        }

        private IEnumerable<GameService> GetValidServices()
        {
            return this.Services
                .Where(service => service != null);
        }
    }
}
