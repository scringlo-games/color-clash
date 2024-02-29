namespace ScringloGames.ColorClash.Runtime.AI.FSM
{
    public interface ITransition
    {
        IState From { get; }
        IState To { get; }
        float Priority { get; }

        bool Evaluate();
    }
}
