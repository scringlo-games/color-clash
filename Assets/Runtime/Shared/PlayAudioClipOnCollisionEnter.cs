using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class PlayAudioClipOnCollisionEnter : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;
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
            
            // If this specific audio source is already playing a clip we don't want to interrupt it
            if (this.audioSource.isPlaying)
            {
                return;
            }
            
            this.audioSource.pitch = (this.pitchVariation * Random.value) + 1.0f;
            this.audioSource.PlayOneShot(this.clip);
        }
    }
}
