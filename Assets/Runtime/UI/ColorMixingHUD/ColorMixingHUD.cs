using System;
using ScringloGames.ColorClash.Runtime.Mixing;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.ColorMixingHUD
{
    public class ColorMixingHUD : MonoBehaviour
    {
        [SerializeField]
        private MixingService mixingService;

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
            Debug.Log($"Mix started! Currently mixing '{args.First}' and '{args.Second}' to make '{args.Result}'!");
        }
        
        private void OnMixCancelled(PaintMixer.MixArgs args)
        {
            Debug.Log($"Mix cancelled! Currently mixing '{args.First}' and '{args.Second}' to make '{args.Result}'!");
        }
        
        private void OnMixCompleted(PaintMixer.MixArgs args)
        {
            Debug.Log($"Mix completed! Currently mixing '{args.First}' and '{args.Second}' to make '{args.Result}'!");
        }
    }
}
