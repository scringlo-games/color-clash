using System;
using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Common.Runtime.Timing;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    /// <summary>
    /// Responsible for managing a set of conditions on a specific entity. This class will maintain a list of
    /// conditions that the entity has, execute the abstracted logic of those conditions, decrement the time of those
    /// conditions and automatically remove them when expired.
    /// </summary>
    public class ConditionBank : MonoBehaviour
    {
        [SerializeField]
        private float tickInterval;
        private List<Condition> conditions;
        private Countdown countdown;
        
        /// <summary>
        /// The conditions that are currently active.
        /// </summary>
        public IEnumerable<Condition> Conditions => this.conditions;

        /// <summary>
        /// Invoked when a condition was applied to this entity.
        /// </summary>
        public event Action<Condition> Applied;
        /// <summary>
        /// Invoked when a condition expires from this entity.
        /// </summary>
        public event Action<Condition> Expired;

        /// <summary>
        /// Applies the specified condition to this entity.
        /// </summary>
        /// <param name="condition">The condition to be applied.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Apply(Condition condition)
        {
            this.conditions.Add(condition);
            condition.OnApplied(this);
            this.Applied?.Invoke(condition);
        }

        private void Awake()
        {
            this.conditions = new List<Condition>();
            this.countdown = new Countdown(this.tickInterval);
        }

        private void OnEnable()
        {
            this.countdown.Elapsed += this.OnCountdownElapsed;
            
            this.countdown.Start();
        }

        private void OnDisable()
        {
            this.countdown.Elapsed -= this.OnCountdownElapsed;
            
            this.countdown.Stop();
        }

        private void Update()
        {
            // Update the countdown
            this.countdown.Tick(Time.deltaTime);
            
            // Find all conditions that have exceeded their duration and expire them
            var conditionsToExpire = this.conditions
                .Where(c => c.Time >= c.Duration)
                .ToList();

            foreach (var condition in conditionsToExpire)
            {
                this.conditions.Remove(condition);
                condition.OnExpired(this);
                this.Expired?.Invoke(condition);
            }
        }

        private void OnCountdownElapsed(ICountdown count)
        {
            foreach (var condition in this.conditions)
            {
                condition.OnTicked(this, Time.deltaTime);
            }
            
            count.Reset();
            count.Restart();
        }
    }
}
