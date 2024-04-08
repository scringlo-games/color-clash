using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Spawning.Old
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private GameObject obj;
        public GameObject ObjectToSpawn { get; private set; }
        
        public void SpawnObject()
        {
            this.ObjectToSpawn = Instantiate(this.obj,this.transform.position, Quaternion.identity);
            
        }
    }
}
