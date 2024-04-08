using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Spawning
{
    public class FixedWaveSpawner : MonoBehaviour
    {
        [SerializeField]
        private bool isContinuous;
        [SerializeField]
        private List<Wave> waves;
        [SerializeField]
        private SpawningService spawningService;
        private Queue<Wave> queue;

        private void OnEnable()
        {
            this.spawningService.Cleared += this.OnWaveCleared;
            
            if (this.spawningService.CurrentWave == null)
            {
                this.queue = new Queue<Wave>();
                
                foreach (var wave in this.waves)
                {
                    this.queue.Enqueue(wave);
                }

                StartCoroutine(SpawnNextWaveAfterDelay(0.1f));
            }
        }

        private void OnDisable()
        {
            this.spawningService.Cleared -= this.OnWaveCleared;
        }

        private IEnumerator SpawnNextWaveAfterDelay(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            this.SpawnNextWave();
        }

        private void SpawnNextWave()
        {
            if (!this.queue.Any())
            {
                return;
            }
            
            var nextWave = this.queue.Dequeue();
            this.spawningService.Spawn(nextWave);
            
            if (this.isContinuous)
            {
                this.queue.Enqueue(nextWave);
            }
        }

        private void OnWaveCleared(Wave obj)
        {
            this.SpawnNextWave();
        }
    }
}
