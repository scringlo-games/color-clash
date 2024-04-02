using System.Collections.Generic;
using System.Linq;
using ScringloGames.ColorClash.Runtime.Environment;
using TravisRFrench.Common.Runtime.ScriptableEvents;
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
        [Header("Events")]
        [SerializeField]
        private ScriptableEvent roomClearedEvent;
        private List<GameObject> currentWaveObjects;
        private int currentWaveIndex = -1;//I hate this
        //private int currentWaveCount;
        private void Awake()
        {
            this.NextWave();
        }

        private void Update()
        {
            if(this.currentWaveIndex < this.waveList.waves.Count)
            {
                foreach(var enemy in this.currentWaveObjects.ToList())
                {
                    if(enemy == null)
                    {
                        this.currentWaveObjects.Remove(enemy);
                    } 
                }
                if(this.currentWaveObjects.Count <= 0)
                {
                    this.NextWave();
                }
            }
        }

        private void NextWave()
        {
            this.currentWaveIndex++;//I hate this too <= It's okay buddy we've all been there :D -TRF
            
            if(this.currentWaveIndex < this.waveList.waves.Count)
            {
                this.currentWaveObjects = new List<GameObject>();
                
                foreach(var point in this.waveList.waves[this.currentWaveIndex].spawnList)
                {
                    point.SpawnObject();
                    this.currentWaveObjects.Add(point.ObjectToSpawn);
                }
            }
            else
            {
                this.roomClearedEvent.Raise();
                this.exit.Activate();
            }
        }
    }
}
