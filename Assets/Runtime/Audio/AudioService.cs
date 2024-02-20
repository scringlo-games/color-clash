using ScringloGames.ColorClash.Runtime.GameServices;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Audio
{
    [CreateAssetMenu(menuName = "Scriptables/Services/Audio Service")]
    public class AudioService : GameService
    {
        private AudioManager manager;
        
        public void SetManager(AudioManager manager)
        {
            this.manager = manager;
        }

        public void PlayClipAtPosition(AudioClip clip, Vector3 position)
        {
            if (this.manager == null)
            {
                return;
            }
            
            this.manager.PlayClipAtPosition(clip, position);
        }
    }
}
