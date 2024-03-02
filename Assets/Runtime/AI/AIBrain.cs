using ScringloGames.ColorClash.Runtime.AI.FSM;
using ScringloGames.ColorClash.Runtime.Movement;
using ScringloGames.ColorClash.Runtime.Weapons;
using TravisRFrench.Common.Runtime.Timing;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public abstract class AIBrain : MonoBehaviour
    {
        [SerializeField]
        private Interval interval;
        private GameObject player;

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

        protected void MoveTowardPlayer(IDestinationMover mover)
        {
            if (mover.HasPath)
            {
                if (!mover.IsMovingOnPath)
                {
                    mover.Resume();
                }
            }
            else
            {
                mover.MoveTo(this.GetPlayer().transform.position);
            }
        }
        
        protected void AttackPlayerIfInRange(Weapon weapon, float range)
        {
            var destination = this.GetPlayer().transform.position;
            var distanceToPlayer = Vector2.Distance(this.transform.position, destination);
            
            if (distanceToPlayer <= range)
            {
                weapon.Trigger.Pull();
            }
            else
            {
                weapon.Trigger.Release();
            }
        }
        
        private void OnIntervalElapsed(IInterval interval)
        {
            this.StateMachine.Update();
            
            this.interval.Reset();
        }

        protected GameObject GetPlayer()
        {
            this.player ??= GameObject.FindWithTag("Player");
            return this.player;
        }
    }
}
