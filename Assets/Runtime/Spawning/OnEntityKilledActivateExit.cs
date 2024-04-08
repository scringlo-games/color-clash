using ScringloGames.ColorClash.Runtime.Environment;
using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Spawning
{
    public class OnEntityKilledActivateExit : MonoBehaviour
    {
        [SerializeField]
        private Killable killable;
        [SerializeField]
        private RoomExit roomExit;

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
            this.roomExit.Activate();
        }
    }
}
