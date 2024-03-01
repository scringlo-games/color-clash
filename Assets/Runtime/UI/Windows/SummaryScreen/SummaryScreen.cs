using ScringloGames.ColorClash.Runtime.Input;
using TravisRFrench.Common.Runtime.ScriptableEvents;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.Windows.SummaryScreen
{
    public class SummaryScreen : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField]
        private Window window;
        [Header("Services")]
        [SerializeField]
        private InputService inputService;
        [Header("Events")]
        [SerializeField]
        private ScriptableEvent roomClearedEvent;

        private void OnEnable()
        {
            this.roomClearedEvent.Raised += this.OnRoomCleared;
        }

        private void OnDisable()
        {
            this.roomClearedEvent.Raised -= this.OnRoomCleared;
        }

        private void OnRoomCleared()
        {
            this.inputService.DisableGameplayInput();
            this.window.Show();
        }
    }
}
