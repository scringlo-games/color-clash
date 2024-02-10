using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.GameServices
{
    public abstract class GameService : ScriptableObject, IGameService
    {
        public bool IsSetup { get; private set; }

        public virtual void Setup()
        {
            this.IsSetup = true;
        }

        public virtual void Teardown()
        {
            this.IsSetup = false;
        }
    }
}
