using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Spawning
{
    public class OnEntityKilledDisableBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Killable killable;
        [SerializeField]
        private Behaviour behaviourToDisable;

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
            behaviourToDisable.enabled = false;
        }
    }
}