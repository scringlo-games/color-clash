using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    /// <summary>
    /// Responsible for encapsulating behaviour that is common between all conditions and for defining a signature
    /// that can be used to treat conditions in the same way by certain systems (such as ConditionBank). Inheritors
    /// should override the OnApplied, OnTicked, and OnExpired methods in order to define condition-specific behavior.
    /// </summary>
    public abstract class Condition : ICloneable<Condition>
    {
        /// <summary>
        /// Determines the duration for which the condition should continue to be active.
        /// </summary>
        public float Duration { get; }
        /// <summary>
        /// The total time for which the condition has been active. This will be initialized at zero and incremented
        /// every frame. When this value reaches <see cref="Duration"/>, the condition will be automatically removed.
        /// </summary>
        public float Time { get; private set; }
        
        /// <param name="duration">The duration of the condition in seconds.</param>
        protected Condition(float duration)
        {
            this.Time = 0f;
            this.Duration = duration;
        }
        
        /// <summary>
        /// Invoked when the condition is first applied to an entity.
        /// </summary>
        /// <param name="bank">The ConditionBank that invokes this callback.</param>
        public virtual void OnApplied(ConditionBank bank)
        {
        }
        
        /// <summary>
        /// Invoked every "tick", as determined by the settings defined in the ConditionBank.
        /// </summary>
        /// <param name="bank">The ConditionBank that invokes this callback.</param>
        /// <param name="deltaTime">The interval in seconds from the last frame to the current one (Read Only).</param>
        public virtual void OnTicked(ConditionBank bank, float deltaTime)
        {
            this.Time = Mathf.Clamp(this.Time, 0f, this.Duration);
        }

        /// <summary>
        /// Invoked when the condition is removed from an entity.
        /// </summary>
        /// <param name="bank">The ConditionBank that invokes this callback.</param>
        public virtual void OnExpired(ConditionBank bank)
        {
        }

        /// <summary>
        /// Clones the condition, creating a deep copy of it.
        /// </summary>
        /// <returns></returns>
        public abstract Condition Clone();
    }
}
