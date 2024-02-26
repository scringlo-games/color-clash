using ScringloGames.ColorClash.Runtime.Audio;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class OnCollisionEnterPlayAudioClip : MonoBehaviour
    {
        [SerializeField]
        private AudioService service;
        [SerializeField]
        private AudioClip clip;
        [SerializeField]
        private float pitchVariation = 0.2f;
        [SerializeField]
        private GameObjectFilterSet filter;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!this.filter.Evaluate(collision.gameObject))
            {
                return;
            }
            
            var pitch = (this.pitchVariation * Random.value) + 1.0f;
            this.service.PlayClipAtPosition(this.clip, this.transform.position, pitch);
        }
    }
}
