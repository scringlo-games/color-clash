using TravisRFrench.Common.Runtime.ScriptableEvents;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class OnKilledRaiseRoomClearedEvent : MonoBehaviour
    {
        [SerializeField]
        private Killable killable;
        [SerializeField]
        private ScriptableEvent roomClearedEvent;

        private void OnEnable()
        {
            this.killable.Killed += OnKilled;
        }

        private void OnDisable()
        {
            this.killable.Killed -= OnKilled;
        }

        private void OnKilled(Killable killable)
        {
            this.roomClearedEvent.Raise();
        }
    }
}