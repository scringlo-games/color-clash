using System;

namespace ScringloGames.ColorClash.Runtime.AI.FSM
{
    public interface IState
    {
        Action OnEntered { get; set; }
        Action OnUpdated { get; set; }
        Action OnExited { get; set; }
    }
}
