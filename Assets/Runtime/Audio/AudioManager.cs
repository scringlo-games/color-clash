using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioService service;

        private void Awake()
        {
            this.service.SetManager(this);
        }

        public void PlayClipAtPosition(AudioClip clip, Vector3 position)
        {
            var instance = new GameObject()
            {
                name = $"Audio Source: {clip.name}",
            };
            instance.transform.position = position;
            var audioSource = instance.AddComponent<AudioSource>();
            
            audioSource.PlayOneShot(clip);
        }
    }
}
