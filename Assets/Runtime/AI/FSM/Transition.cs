using System;

namespace ScringloGames.ColorClash.Runtime.AI.FSM
{
    public class Transition : ITransition
    {
        public IState From { get; set; }
        public IState To { get; set; }
        public float Priority { get; set; }
        public Func<bool> Condition { get; set; }

        public bool Evaluate()
        {
            return this.Condition.Invoke();
        }
    }
}
