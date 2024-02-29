using ScringloGames.ColorClash.Runtime.AI.FSM;
using TravisRFrench.Common.Runtime.Timing;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public abstract class AIBrain : MonoBehaviour
    {
        [SerializeField]
        private Interval interval;

        protected abstract IStateMachine StateMachine { get; }

        protected virtual void OnEnable()
        {
            this.interval.Elapsed += this.OnIntervalElapsed;
        }

        protected virtual void OnDisable()
        {
            this.interval.Elapsed -= this.OnIntervalElapsed;
        }
        
        protected virtual void Update()
        {
            if (!this.interval.IsRunning)
            {
                this.interval.Start();
            }
            
            this.interval.Tick(Time.deltaTime);
        }
        
        private void OnIntervalElapsed(IInterval interval)
        {
            this.StateMachine.Update();
            
            this.interval.Reset();
        }
    }
}
