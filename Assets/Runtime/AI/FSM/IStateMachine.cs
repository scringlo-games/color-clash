using System.Collections.Generic;

namespace ScringloGames.ColorClash.Runtime.AI.FSM
{
    public interface IStateMachine
    {
        IState StartingState { get; }
        IState CurrentState { get; }
        IEnumerable<ITransition> Transitions { get; }
        
        void AddTransition(ITransition transition);
        void RemoveTransition(ITransition transition);
        void Update();
    }
}
