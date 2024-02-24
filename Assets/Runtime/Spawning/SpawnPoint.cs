using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private GameObject obj;
        public GameObject spawnedObj;
        public void SpawnObject()
        {
            this.spawnedObj = Instantiate(obj,this.transform.position, Quaternion.identity);
            
        }
    }
}
