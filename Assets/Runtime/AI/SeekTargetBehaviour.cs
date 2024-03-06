using System;
using ScringloGames.ColorClash.Runtime.Movement;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public class SeekTargetBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float minimumDistance = 0.05f;
        [SerializeField]
        private float maximumDistance = Mathf.Infinity;
        [SerializeField]
        private float deltaDistance = 0.5f;
        [Header("Dependencies")]
        [SerializeField]
        private AStarDestinationMover mover;
        private GameObject target;

        private void OnEnable()
        {
            this.target = GameObject.FindWithTag("Player");
            this.mover.MoveTo(this.target.transform.position);
        }

        private void OnDisable()
        {
            this.mover.Halt();
        }

        private void Update()
        {
            if (this.target == null)
            {
                return;
            }
            
            var from = this.mover.transform.position;
            var to = this.target.transform.position;
            var distanceToTarget = Vector2.Distance(from, to);

            if (distanceToTarget <= this.minimumDistance || distanceToTarget >= this.maximumDistance)
            {
                return;
            }

            if (Vector2.Distance(this.mover.Destination, to) > this.deltaDistance)
            {
                this.mover.MoveTo(to);
            }
        }
    }
}
