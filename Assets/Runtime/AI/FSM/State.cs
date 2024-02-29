using System;

namespace ScringloGames.ColorClash.Runtime.AI.FSM
{
    public class State : IState
    {
        public Action OnEntered { get; set; }
        public Action OnUpdated { get; set; }
        public Action OnExited { get; set; }
    }
}
