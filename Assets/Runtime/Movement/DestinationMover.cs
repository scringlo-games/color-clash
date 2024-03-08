using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Movement
{
    public class DestinationMover : MonoBehaviour, IDestinationMover
    {
        [SerializeField]
        private DirectionalMover directionalMover;
        [SerializeField]
        private float stoppingDistance = 0.05f;

        public bool HasPath { get; private set; }
        public bool IsMovingOnPath { get; private set; }
        public Vector2 Destination { get; private set; }
        public event Action Started;
        public event Action Arrived;
        public event Action Terminated;

        public void MoveTo(Vector2 destination)
        {
            this.Destination = destination;
            
            var from = (Vector2)this.transform.position;
            var to = this.Destination;
            var direction = (to - from).normalized;
            
            this.directionalMover.Direction = direction;
            this.directionalMover.StartAccelerating();
            
            this.HasPath = true;
            this.IsMovingOnPath = true;
            this.Started?.Invoke();
        }

        public void Halt()
        {
            this.directionalMover.StopAccelerating();
            this.IsMovingOnPath = false;
        }

        public void Resume()
        {
            this.IsMovingOnPath = true;
        }

        public void Cancel()
        {
            this.Halt();
            this.HasPath = false;
            this.Terminated?.Invoke();
        }

        private void Update()
        {
            if (this.directionalMover == null)
            {
                return;
            }

            if (this.HasPath)
            {
                if (this.IsMovingOnPath)
                {
                    var from = (Vector2)this.transform.position;
                    var to = this.Destination;
                    var distance = Vector3.Distance(from, to);
                
                    if (distance <= this.stoppingDistance)
                    {
                        this.Arrived?.Invoke();
                        this.Cancel();
                    }
                }
            }
        }
    }
}
