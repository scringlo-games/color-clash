using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Movement
{
    public interface IDestinationMover
    {
        bool IsMoving { get; }
        Vector2 Destination { get; }

        event Action Arrived;
        
        void MoveTo(Vector2 destination);
        void Halt();
    }
}
