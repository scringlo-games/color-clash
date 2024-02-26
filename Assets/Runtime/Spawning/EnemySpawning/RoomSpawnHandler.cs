using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Environment;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Spawning.EnemySpawning
{
    [System.Serializable]
    public class Wave
    {
        public List<SpawnPoint> spawnList;
    }
    [System.Serializable]
    public class WaveList
    {
        public List<Wave> waves;       
    }
    public class RoomSpawnHandler : MonoBehaviour
    {
        [SerializeField]
        private RoomExit exit;
        [SerializeField]
        public WaveList waveList = new WaveList();
        private List<GameObject> currentWaveObjects;
        private int currentWaveIndex = -1;//I hate this
        //private int currentWaveCount;
        void Awake()
        {
            this.NextWave();
        }
        void Update()
        {
            if(this.currentWaveIndex < this.waveList.waves.Count)
            {
                foreach(var enemy in this.currentWaveObjects)
                {
                    if(enemy == null)
                    {
                        this.currentWaveObjects.Remove(enemy);
                        Debug.Log($"Remaining Enemies: {this.currentWaveObjects.Count}");
                    } 
                }
                if(this.currentWaveObjects.Count <= 0)
                {
                    this.NextWave();
                }
            }
        }
        void NextWave()
        {
            this.currentWaveIndex++;//I hate this too
            
            if(this.currentWaveIndex < this.waveList.waves.Count)
            {
                this.currentWaveObjects = new List<GameObject>();
                
                foreach(var point in this.waveList.waves[this.currentWaveIndex].spawnList)
                {
                    point.SpawnObject();
                    this.currentWaveObjects.Add(point.spawnedObj);
                }
            }
            else
            {
                //activate transition object then return
                this.exit.Activate();
                Debug.Log("ROOM COMPLETE");
            }
        }
    }
}
