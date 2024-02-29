using System;
using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Movement
{
    public class AStarDestinationMover : MonoBehaviour, IDestinationMover
    {
        [SerializeField]
        private DestinationMover destinationMover;
        [SerializeField]
        private Seeker seeker;
        
        private Queue<Vector2> queue;

        public bool IsMoving => this.destinationMover.IsMoving;
        public Vector2 Destination => this.destinationMover.Destination;
        
        public event Action Arrived;

        public void MoveTo(Vector2 destination)
        {
            var from = this.transform.position;
            var to = destination;

            this.seeker.StartPath(from, to, this.OnPathFound);
        }

        public void Halt()
        {
            this.destinationMover.Halt();
        }
        
        private void Awake()
        {
            this.queue = new Queue<Vector2>();
        }

        private void OnEnable()
        {
            this.destinationMover.Arrived += this.OnDestinationArrived;
        }
        
        private void OnDisable()
        {
            this.destinationMover.Arrived -= this.OnDestinationArrived;
        }

        private void MoveToNextPointOnPath()
        {
            if (this.queue == null)
            {
                return;
            }

            if (!this.queue.Any())
            {
                return;
            }
            
            var destination = this.queue.Dequeue();
            this.destinationMover.MoveTo(destination);
        }
        
        private void OnPathFound(Path path)
        {
            foreach (var waypoint in path.vectorPath)
            {
                this.queue.Enqueue(waypoint);
            }
            
            this.MoveToNextPointOnPath();
        }
        
        private void OnDestinationArrived()
        {
            this.MoveToNextPointOnPath();
        }
    }
}
