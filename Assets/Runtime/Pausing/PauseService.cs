using ScringloGames.ColorClash.Runtime.GameServices;
using TravisRFrench.Common.Runtime.ScriptableEvents;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Pausing
{
    [CreateAssetMenu(menuName = "Scriptables/Game Services/Pause Service")]
    public class PauseService : GameService
    {
        [Header("Events")]
        [SerializeField]
        private ScriptableEvent gamePausedEvent;
        [SerializeField]
        private ScriptableEvent gameResumedEvent;
        
        public bool IsPaused { get; private set; }

        public void Pause()
        {
            this.IsPaused = true;
            this.gamePausedEvent.Raise();

            Time.timeScale = 0f;
        }

        public void Resume()
        {
            this.IsPaused = false;
            this.gameResumedEvent.Raise();

            Time.timeScale = 1f;
        }

        public void Toggle()
        {
            if (this.IsPaused)
            {
                this.Resume();
            }
            else
            {
                this.Pause();
            }
        }
    }
}