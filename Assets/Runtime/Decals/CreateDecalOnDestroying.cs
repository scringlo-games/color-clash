using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScringloGames.ColorClash.Runtime.Decals
{
    public class CreateDecalOnDestroying : MonoBehaviour
    {
        private static int spriteCount;
        
        private Vector3 angle;
        [SerializeField]
        private List<GameObject> spawnObjects;
        [SerializeField]
        private Destructible destructible;
        [SerializeField]
        private bool randomRotation = true;
        [SerializeField]
        private float scaleVariation;
        private System.Random rnd = new System.Random();
        
        private void OnEnable()
        {
            this.destructible.Destroying += this.OnDestroying;
        }

        private void OnDisable()
        {
            this.destructible.Destroying -= this.OnDestroying;
        }
        
        public void CreateNewSprite(Vector3 targetPos)
        {
            
            //randomly selects one spawn object from the list of spawn objects to be spawned. 
            int objI = rnd.Next(spawnObjects.Count);
            GameObject spawnObj = spawnObjects[objI];

            if(randomRotation)
            {
                this.angle = new Vector3 (0f,0f, Random.Range(-90f, 90f));
            }
            else 
            {
                this.angle = Vector3.zero;
            }
            /*creates a new instance of the given prefab, then finds the spriterenderer component on the prefab and increments the sorting 
            order by one, ensuring that paint decals are rendered in the correct order. */
            var newObj = Instantiate(spawnObj,targetPos, Quaternion.Euler(this.angle));
            newObj.GetComponent<SpriteRenderer>().sortingOrder = spriteCount++;

            //modifies the scale of the newyly spawned object to a random value within the range determined by scaleVariation. 
            // Vector3 newObjScale = newObj.transform.localScale;
            // float newScaleNum = Random.Range(scaleVariation * -1f, scaleVariation);
            // Debug.Log($"scale num: {newScaleNum}");
            // newObj.transform.localScale = new Vector3(newObjScale.x + newScaleNum, newObjScale.y + newScaleNum, 1f);
            
            Debug.Log($"decal pos: {newObj.transform.position}");
            Debug.Log($"sprite count: {spriteCount}");
        }
        
        private void OnDestroying(Destructible entity)
        {
            this.CreateNewSprite(this.destructible.transform.position);
        }
    }
}
