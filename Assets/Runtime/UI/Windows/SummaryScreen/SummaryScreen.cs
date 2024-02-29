using TravisRFrench.Common.Runtime.ScriptableEvents;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.Windows.SummaryScreen
{
    public class SummaryScreen : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField]
        private Window window;
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
            this.window.Show();
        }
    }
}
