using System.Collections.Generic;
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
            foreach (var service in this.Services)
            {
                service.Setup();
            }
        }

        private void OnDestroy()
        {
            foreach (var service in this.Services)
            {
                service.Teardown();
            }
        }
    }
}
