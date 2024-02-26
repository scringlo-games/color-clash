using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioService service;
        private List<AudioSource> sources;
        private const float cleanupInterval = 1f;

        private void Awake()
        {
            this.sources = new List<AudioSource>();
            this.service.SetManager(this);
        }

        private void OnEnable()
        {
            this.StartCoroutine(this.CheckForSourcesToCleanup());
        }

        private IEnumerator CheckForSourcesToCleanup()
        {
            yield return new WaitForSeconds(cleanupInterval);

            var sourceToCleanup = this.sources
                .Where(source => !source.isPlaying)
                .ToList();

            foreach (var source in sourceToCleanup)
            {
                var destructible = source.GetComponent<Destructible>();

                if (destructible != null)
                {
                    destructible.Destroy();
                }
                
                this.sources.Remove(source);
            }
            
            yield return this.CheckForSourcesToCleanup();
        }

        public void PlayClipAtPosition(AudioClip clip, Vector3 position, float pitch = 1f)
        {
            var instance = new GameObject
            {
                name = $"Audio Source: {clip.name}",
                transform =
                {
                    position = position
                }
            };
            instance.transform.SetParent(this.transform);
            var audioSource = instance.AddComponent<AudioSource>();
            var destructible = instance.AddComponent<Destructible>();

            audioSource.pitch = pitch;
            audioSource.PlayOneShot(clip);
            
            this.sources.Add(audioSource);
        }
    }
}
