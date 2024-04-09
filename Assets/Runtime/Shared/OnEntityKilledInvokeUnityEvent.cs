using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class OnEntityKilledInvokeUnityEvent : MonoBehaviour
    {
        [SerializeField]
        private Killable killable;
        [SerializeField]
        private UnityEvent<Killable> response;

        private void OnEnable()
        {
            this.killable.Killed += this.OnKilled;
        }

        private void OnDisable()
        {
            this.killable.Killed -= this.OnKilled;
        }

        private void OnKilled(Killable killable)
        {
            this.response.Invoke(killable);
        }
    }
}
