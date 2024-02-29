using System.Collections.Generic;
using System.Linq;

namespace ScringloGames.ColorClash.Runtime.AI.FSM
{
    public class StateMachine : IStateMachine
    {
        private readonly List<ITransition> transitions;
        public IState StartingState { get; }
        public IState CurrentState { get; private set; }

        public IEnumerable<ITransition> Transitions => this.transitions;

        public StateMachine(IState startingState)
        {
            this.StartingState = startingState;

            this.transitions = new List<ITransition>();
            
            this.ChangeState(this.StartingState);
        }

        public void AddTransition(ITransition transition)
        {
            this.transitions.Add(transition);
        }

        public void RemoveTransition(ITransition transition)
        {
            this.transitions.Remove(transition);
        }

        public void Update()
        {
            this.EvaluateTransitions();

            if (this.CurrentState != null)
            {
                this.CurrentState.OnUpdated?.Invoke();
            }
        }

        private void EvaluateTransitions()
        {
            if (!this.Transitions.Any())
            {
                return;
            }
            
            var transition = this.Transitions
                .Where(transition => transition.From == this.CurrentState)
                .OrderByDescending(transition => transition.Priority)
                .FirstOrDefault(transition => transition.Evaluate());

            if (transition == null)
            {
                return;
            }

            this.ChangeState(transition.To);
        }

        private void ChangeState(IState state)
        {
            if (state == null)
            {
                return;
            }

            if (this.CurrentState != null)
            {
                this.CurrentState.OnExited?.Invoke();
            }
            
            this.CurrentState = state;

            state.OnEntered?.Invoke();
        }
    }
}
