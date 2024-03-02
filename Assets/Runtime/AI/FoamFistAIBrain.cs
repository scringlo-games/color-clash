using ScringloGames.ColorClash.Runtime.AI.FSM;
using ScringloGames.ColorClash.Runtime.Movement;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public class FoamFistAIBrain : AIBrain
    {
        private IStateMachine stateMachine;
        [SerializeField]
        private AStarDestinationMover mover;

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
            
            this.stateMachine = new StateMachine();
        }

        private bool OnIdleToSeekTransitionEvaluated()
        {
            return this.GetPlayer() != null;
        }
        
        private bool OnSeekToIdleTransitionEvaluated()
        {
            return this.GetPlayer() == null;
        }
        
        private void OnIdleEntered()
        {
            this.mover.Halt();
        }
        
        private void OnSeekUpdated()
        {
        }
    }
}
