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

        public bool IsMoving { get; private set; }
        public Vector2 Destination { get; private set; }
        public event Action Arrived;

        public void MoveTo(Vector2 destination)
        {
            this.Destination = destination;
            this.IsMoving = true;
        }

        public void Halt()
        {
            this.Destination = this.transform.position;
            this.IsMoving = false;
        }

        private void Update()
        {
            if (this.directionalMover == null)
            {
                return;
            }
            
            if (this.IsMoving)
            {
                var from = (Vector2)this.transform.position;
                var to = this.Destination;
                var distance = Vector3.Distance(from, to);
                
                if (distance <= this.stoppingDistance)
                {
                    this.Halt();
                    this.Arrived?.Invoke();
                }

                this.directionalMover.Direction = (to - from);

                if (!this.directionalMover.IsAccelerating)
                {
                    this.directionalMover.StartAccelerating();
                }
            }
            else
            {
                if (this.directionalMover.IsAccelerating)
                {
                    this.directionalMover.StopAccelerating();
                }
            }
        }
    }
}
