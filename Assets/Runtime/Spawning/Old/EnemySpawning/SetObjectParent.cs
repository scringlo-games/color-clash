using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Spawning.Old.EnemySpawning
{
    public class SetObjectParent : MonoBehaviour
    {
        [SerializeField]
        private GameObject target;
        [SerializeField]
        private string targetNewParent;
        void OnEnable()
        {
            this.target.transform.parent = GameObject.Find(targetNewParent).transform;
        }
    }
}
