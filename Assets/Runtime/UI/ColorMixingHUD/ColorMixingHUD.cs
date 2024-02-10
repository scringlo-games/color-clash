using System;
using DG.Tweening;
using ScringloGames.ColorClash.Runtime.Mixing;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.UI.ColorMixingHUD
{
    public class ColorMixingHUD : MonoBehaviour
    {
        [SerializeField]
        private MixingService mixingService;
        [SerializeField]
        private ColorMixingHUDNode left;
        [SerializeField]
        private ColorMixingHUDNode right;
        
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
            this.left.gameObject.SetActive(true);
            this.right.gameObject.SetActive(false);
            
            this.left.SetColor(args.First.Color);
            this.left.Center();

            DOTween.Sequence()
                .Append(this.left.FadeIn())
                .Play();
        }
        
        private void OnMixCancelled(PaintMixer.MixArgs args)
        {
        }
        
        private void OnMixCompleted(PaintMixer.MixArgs args)
        {
            this.left.gameObject.SetActive(true);
            this.right.gameObject.SetActive(true);
            
            this.left.SetColor(args.First.Color);
            this.right.SetColor(args.Second.Color);
            
            DOTween.Sequence()
                .Insert(0, this.right.FadeIn())
                .Insert(0, this.left.PushLeft())
                .Play();
        }
    }
}
