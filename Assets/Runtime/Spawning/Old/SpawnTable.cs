using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScringloGames.ColorClash.Runtime.Spawning.Old
{
    public class SpawnTable : ScriptableObject
    {
        [SerializeField]
        private List<GameObject> prefabsToSpawn;
        
        public GameObject Select()
        {
            // Developer's note: We don't yet have support for weighted randoms or anything similar, so for now we can
            // just add multiple instances of the same prefab to alter the probability of it being spawned.
            
            var randomIndex = Random.Range(0, this.prefabsToSpawn.Count);
            var selected = this.prefabsToSpawn[randomIndex];

            return selected;
        }
    }
}
