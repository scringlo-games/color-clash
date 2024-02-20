using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime;
using ScringloGames.ColorClash.Runtime.GameServices;
using UnityEngine;

namespace ScringloGames.ColorClash.Tests.PlayMode
{
    [CreateAssetMenu(menuName = "Scriptables/Test Configurations/Play Mode")]
    public class PlayModeTestConfiguration : ScriptableObject
    {
        public RegistrarSet Registrars;
        public List<GameService> Services;
        public GameObject enemyPrefab;

        public GameObject EnemyPrefab => this.enemyPrefab;

        public void Setup()
        {
            this.Registrars.Setup();

            foreach (var service in this.Services)
            {
                service.Setup();
            }
        }

        public void Teardown()
        {
            foreach (var service in this.Services)
            {
                service.Teardown();
            }
        }
    }
}
