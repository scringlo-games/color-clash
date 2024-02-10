using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.GameServices
{
    public class GameServiceManager : MonoBehaviour
    {
        [SerializeField]
        private List<GameService> services;

        public IEnumerable<GameService> Services => this.services;

        private void Awake()
        {
            foreach (var service in this.Services
                         .Where(s => !s.IsSetup))
            {
                service.Setup();
            }
        }

        private void OnDestroy()
        {
            foreach (var service in this.Services
                         .Where(s => s.IsSetup))
            {
                service.Teardown();
            }
        }
    }
}
