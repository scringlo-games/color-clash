using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Spawning
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private GameObject obj;
        public GameObject spawnedObj {get; private set;}
        public void SpawnObject()
        {
            this.spawnedObj = Instantiate(this.obj,this.transform.position, Quaternion.identity);
            
        }
    }
}
