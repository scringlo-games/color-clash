namespace ScringloGames.ColorClash.Runtime.GameServices
{
    public interface IGameService
    {
        bool IsSetup { get; }
        
        void Setup();
        void Teardown();
    }
}
