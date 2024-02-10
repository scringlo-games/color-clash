using System;
using ScringloGames.ColorClash.Runtime.Mixing;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.ColorMixingHUD
{
    public class ColorMixingHUD : MonoBehaviour
    {
        [SerializeField]
        private MixingService mixingService;
        [SerializeField]
        private GameObject firstContainer;
        [SerializeField]
        private GameObject secondContainer;
        
        private void OnEnable()
        {
            this.mixingService.Mixer.MixStarted += this.OnMixStarted;
            this.mixingService.Mixer.MixCancelled += this.OnMixCancelled;
            this.mixingService.Mixer.MixCompleted += this.OnMixCompleted;
        }
        
        private void OnDisable()
        {
            this.mixingService.Mixer.MixStarted -= this.OnMixStarted;
            this.mixingService.Mixer.MixCancelled -= this.OnMixCancelled;
            this.mixingService.Mixer.MixCompleted -= this.OnMixCompleted;
        }

        private void OnMixStarted(PaintMixer.MixArgs args)
        {
            Debug.Log($"Mix started!");
        }
        
        private void OnMixCancelled(PaintMixer.MixArgs args)
        {
            Debug.Log($"Mix cancelled!");
        }
        
        private void OnMixCompleted(PaintMixer.MixArgs args)
        {
            Debug.Log($"Mix completed!");
            Debug.Log($"Result: {args.Result}");
        }
    }
}
