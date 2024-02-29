using ScringloGames.ColorClash.Runtime.AI.FSM;
using ScringloGames.ColorClash.Runtime.Movement;
using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public class NewInternAIBrain : AIBrain
    {
        [SerializeField]
        private float attackDistance = 1f;
        [Header("Dependencies")]
        [SerializeField]
        private Weapon weapon;
        [SerializeField]
        private AStarDestinationMover mover;
        private StateMachine stateMachine;
        private GameObject player;

        protected override IStateMachine StateMachine => this.stateMachine;

        private void Awake()
        {
            var idleState = new State()
            {
                OnEntered = this.OnIdleEntered,
            };

            var seekState = new State()
            {
                OnUpdated = this.OnSeekUpdated,
            };

            this.stateMachine = new StateMachine(idleState);
            
            var idleToSeekTransition = new Transition()
            {
                From = idleState,
                To = seekState,
                Condition = this.OnIdleToSeekTransitionEvaluated,
            };

            var seekToIdleTransition = new Transition()
            {
                From = seekState,
                To = idleState,
                Condition = this.OnSeekToIdleTransitionEvaluated
            };
            
            this.stateMachine.AddTransition(idleToSeekTransition);
            this.stateMachine.AddTransition(seekToIdleTransition);
        }

        private GameObject GetPlayer()
        {
            this.player ??= GameObject.FindWithTag("Player");
            return this.player;
        }

        private void OnIdleEntered()
        {
            this.mover.Halt();
        }
        
        private void OnSeekUpdated()
        {
            if (this.mover.HasPath)
            {
                if (!this.mover.IsMovingOnPath)
                {
                    this.mover.Resume();
                }
            }
            else
            {
                this.mover.MoveTo(this.GetPlayer().transform.position);
            }
            
            var destination = this.GetPlayer().transform.position;
            var distance = Vector2.Distance(this.transform.position, destination);
            
            if (distance <= this.attackDistance)
            {
                this.weapon.Trigger.Pull();
            }
            else
            {
                this.weapon.Trigger.Release();
                this.mover.MoveTo(destination);
            }
        }
        
        private bool OnIdleToSeekTransitionEvaluated()
        {
            return this.GetPlayer() != null;
        }
        
        private bool OnSeekToIdleTransitionEvaluated()
        {
            return this.GetPlayer() == null;
        }
    }
}
