using ScringloGames.ColorClash.Runtime.Audio;
using ScringloGames.ColorClash.Runtime.Shared.Contact;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class OnCollisionEnterPlayAudioClip : ContactBehaviour
    {
        [SerializeField]
        private AudioService service;
        [SerializeField]
        private AudioClip clip;
        [SerializeField]
        private float pitchVariation = 0.2f;
        [SerializeField]
        private GameObjectFilterSet filter;

        public override void OnCollisionEntered(Collision2D collision2D)
        {
            if (!this.filter.Evaluate(collision2D.gameObject))
            {
                return;
            }
            
            var pitch = (this.pitchVariation * Random.value) + 1.0f;
            this.service.PlayClipAtPosition(this.clip, this.transform.position, pitch);
        }
    }
}
