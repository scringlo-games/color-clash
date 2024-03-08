using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Movement
{
    /// <summary>
    /// Declares an interface for an entity that can move along a path toward a specified destination.
    /// </summary>
    public interface IDestinationMover
    {
        /// <summary>
        /// Does the entity currently have a path?
        /// </summary>
        bool HasPath { get; }
        /// <summary>
        /// Is the entity currently moving along a path?
        /// </summary>
        bool IsMovingOnPath { get; }
        /// <summary>
        /// The destination that the entity is trying to reach.
        /// </summary>
        Vector2 Destination { get; }

        /// <summary>
        /// Invoked when a path is started.
        /// </summary>
        event Action Started;
        /// <summary>
        /// Invoked when the entity arrives at its destination.
        /// </summary>
        event Action Arrived;
        /// <summary>
        /// Invoked when the path is terminated, either through completion or cancellation.
        /// </summary>
        event Action Terminated;

        /// <summary>
        /// Starts a path moving toward the specified destination.
        /// </summary>
        /// <param name="destination"></param>
        void MoveTo(Vector2 destination);
        /// <summary>
        /// Stops moving along the current path but does not cancel it.
        /// </summary>
        void Halt();
        /// <summary>
        /// Continues moving along the current path, even if previously halted.
        /// </summary>
        void Resume();
        /// <summary>
        /// Cancels the current path.
        /// </summary>
        void Cancel();
    }
}
