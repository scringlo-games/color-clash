using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.PainSplatter
{
    public class TempSpriteSpawner : MonoBehaviour
    {
    
        private Vector3 angle;
        [SerializeField] private GameObject spawnObj;
        private static int spriteCount;

        private void OnDisable()
        {
            this.CreateNewSprite(this.transform.position);
        }
        public void CreateNewSprite(Vector3 targetPos)
        {
            /*creates a new instance of the given prefab, then finds the spriterenderer component on the prefab and increments the sorting 
            order by one, ensuring that paint decals are rendered in the correct order. */
            this.angle = new Vector3 (0f,0f, Random.Range(-90f, 90f));
            var newObj = Instantiate(this.spawnObj,targetPos, Quaternion.Euler(this.angle));
            newObj.GetComponent<SpriteRenderer>().sortingOrder = spriteCount++;
            Debug.Log($"decal pos: {newObj.transform.position}");
            Debug.Log($"sprite count: {spriteCount}");
        }
    
    }
}
