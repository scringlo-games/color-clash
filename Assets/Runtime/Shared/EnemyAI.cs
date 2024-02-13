using ScringloGames.ColorClash.Runtime.Movement;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField]
        private string moveToTag = "Player";
        [SerializeField]
        private DirectionalMover mover;
        private GameObject moveToTarget;

        private void Awake()
        {
            this.moveToTarget = GameObject.FindGameObjectWithTag(this.moveToTag);
        }

        private void OnEnable()
        {
            this.mover.StartAccelerating();
        }

        private void Update()
        {
            var from = this.transform.position;
            var to = this.moveToTarget.transform.position;
            var direction = (to - from).normalized;
            
            this.mover.Direction = direction;
        }
    }
}
