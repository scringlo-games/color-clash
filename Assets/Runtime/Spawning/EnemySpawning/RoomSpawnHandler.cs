using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
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
        public WaveList waveList = new WaveList();
        private List<GameObject> currentWaveObjects;
        private int currentWaveIndex = -1;//I hate this
        private int currentWaveCount;
        void Awake()
        {
            NextWave();
        }
        void Update()
        {
            if(currentWaveIndex < waveList.waves.Count)
            {
                foreach(GameObject enemy in currentWaveObjects)
                {
                    if(enemy == null)
                    {
                        currentWaveObjects.Remove(enemy);
                        Debug.Log($"Remaining Enemies: {currentWaveObjects.Count}");
                    } 
                }
                if(currentWaveObjects.Count <= 0)
                {
                    NextWave();
                }
            }
        }
        void NextWave()
        {
            currentWaveIndex++;//I hate this too
            Debug.Log($"current wave Index: {currentWaveIndex}");
            if(currentWaveIndex < waveList.waves.Count)
            {
                currentWaveObjects = new List<GameObject>();
                currentWaveCount = waveList.waves[currentWaveIndex].spawnList.Count;
                foreach(SpawnPoint point in waveList.waves[currentWaveIndex].spawnList)
                {
                    point.SpawnObject();
                    currentWaveObjects.Add(point.spawnedObj);
                }
            }
            else
            {
                //activate transition object then return
                Debug.Log("ROOM COMPLETE");
            }
        }
    }
}
