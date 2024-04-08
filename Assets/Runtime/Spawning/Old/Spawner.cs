using System.Collections;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Spawning.Old
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private SpawnTable spawnTable;
        [SerializeField]
        private float interval = 10f;

        [SerializeField] private int spawnAmount = 1;

        private void OnEnable()
        {
            this.StartCoroutine(this.SpawnPrefab());
        }

        private IEnumerator SpawnPrefab()
        {
            if (this.TryGetComponent(out AudioSource audioSource))
            {
                audioSource.Play();
            }

            for (int i = 0; i < spawnAmount; i++)
            {
                var prefab = this.spawnTable.Select();
                Instantiate(prefab, this.transform.position, Quaternion.identity, null);
            }
            

            yield return new WaitForSeconds(this.interval);
            yield return this.SpawnPrefab();
        }
    }
}
