using ScringloGames.ColorClash.Runtime.Environment;
using TravisRFrench.Common.Runtime.ScriptableEvents;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class OnRoomClearedActivateExit : MonoBehaviour
    {
        [SerializeField]
        private RoomExit exit;
        [SerializeField]
        private ScriptableEvent roomClearedEvent;
        
        private void OnEnable()
        {
            this.roomClearedEvent.Raised += OnRoomCleared;
        }

        private void OnDisable()
        {
            this.roomClearedEvent.Raised -= OnRoomCleared;
        }

        private void OnRoomCleared()
        {
            this.exit.Activate();
        }
    }
}