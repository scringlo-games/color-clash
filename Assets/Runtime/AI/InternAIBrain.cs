using ScringloGames.ColorClash.Runtime.AI.FSM;
using ScringloGames.ColorClash.Runtime.Movement;
using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public class InternAIBrain : AIBrain
    {
        [SerializeField]
        private float range = 1f;
        [Header("Dependencies")]
        [SerializeField]
        private Weapon weapon;
        [SerializeField]
        private AStarDestinationMover mover;
        private StateMachine stateMachine;

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

        private void OnIdleEntered()
        {
            this.mover.Halt();
        }
        
        private void OnSeekUpdated()
        {
            this.MoveTowardPlayer(this.mover);
            this.AttackPlayerIfInRange(this.weapon, this.range);
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
