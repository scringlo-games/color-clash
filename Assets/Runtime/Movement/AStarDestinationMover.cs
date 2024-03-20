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
        private float stoppingDistance = 0.05f;
        [Header("Dependencies")]
        [SerializeField]
        private DestinationMover destinationMover;
        [SerializeField]
        private Seeker seeker;
        private Queue<Vector2> queue;

        public bool HasPath { get; private set; }
        public bool IsMovingOnPath => this.destinationMover.IsMovingOnPath;
        public Vector2 Destination => this.destinationMover.Destination;
        public event Action Started;
        public event Action Cancelled;

        public event Action Arrived;
        public event Action Terminated;

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

        public void Resume()
        {
            this.destinationMover.Resume();
        }

        public void Cancel()
        {
            this.destinationMover.Cancel();
            this.HasPath = false;
            this.Cancelled?.Invoke();
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
            
            var from = (Vector2)this.transform.position;

            while ((this.queue.Any()) && Vector2.Distance(from, this.queue.Peek()) <= this.stoppingDistance)
            {
                this.queue.Dequeue();
            }

            if (this.queue.Count <= 0)
            {
                this.Arrived?.Invoke();
                this.Cancel();
                return;
            }

            var destination = this.queue.Dequeue();
            this.destinationMover.MoveTo(destination);
        }
        
        private void OnPathFound(Path path)
        {
            this.queue.Clear();
            
            foreach (var waypoint in path.vectorPath)
            {
                this.queue.Enqueue(waypoint);
            }

            this.HasPath = true;
            this.Started?.Invoke();
            this.MoveToNextPointOnPath();
        }
        
        private void OnDestinationArrived()
        {
            this.MoveToNextPointOnPath();
        }
    }
}
