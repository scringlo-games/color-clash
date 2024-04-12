using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScringloGames.ColorClash.Runtime.Spawning
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private float radius = 1f;
        [SerializeField]
        private SpawningService spawningService;

        public float Radius
        {
            get => radius;
            set => radius = value;
        }

        public IEnumerable<GameObject> Spawn(Wave wave)
        {
            var results = new List<GameObject>();
            
            foreach (var prefab in wave.Prefabs)
            {
                var position = this.transform.position + (Vector3)Random.insideUnitCircle * this.radius;
                var instance = Instantiate(prefab, position, Quaternion.identity);
                
                results.Add(instance);
            }

            return results;
        }

        private void OnEnable()
        {
            this.spawningService.SpawnPoints.Register(this);
        }

        private void OnDisable()
        {
            this.spawningService.SpawnPoints.Deregister(this);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(this.transform.position, this.radius);
        }
    }
}
