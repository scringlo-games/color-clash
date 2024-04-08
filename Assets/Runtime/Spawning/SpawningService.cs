using System;
using System.Collections.Generic;
using System.Linq;
using ScringloGames.ColorClash.Runtime.GameServices;
using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Spawning
{
    public class SpawningService : GameService
    {
        private List<GameObject> remainingEnemies;
        public Wave CurrentWave { get; private set; }
        public SpawnPointRegistrar SpawnPoints { get; private set; }

        public event Action<Wave> Spawned;
        public event Action<Wave> Cleared;

        public override void Setup()
        {
            this.CurrentWave = null;
            this.SpawnPoints = new SpawnPointRegistrar();
        }

        public override void Teardown()
        {
            this.CurrentWave = null;
        }

        public IEnumerable<GameObject> Spawn(Wave wave)
        {
            var results = new List<GameObject>();
            this.CurrentWave = wave;
            
            foreach (var point in this.SpawnPoints.Entities)
            {
                var instances = point.Spawn(wave);

                foreach (var instance in instances)
                {
                    results.Add(instance);
                    
                    var killable = instance.GetComponent<Killable>();
                    killable.Killed += OnKilled;
                }
            }

            this.remainingEnemies = results.ToList();
            this.Spawned?.Invoke(wave);
            
            return results;
        }

        private void OnKilled(Killable killable)
        {
            this.remainingEnemies.Remove(killable.gameObject);
            
            if (!this.remainingEnemies.Any())
            {
                this.Cleared?.Invoke(this.CurrentWave);
            }
        }
    }
}
