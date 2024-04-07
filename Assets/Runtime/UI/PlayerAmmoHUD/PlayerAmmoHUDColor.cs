using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Mixing;
using UnityEngine;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime
{
    public class PlayerAmmoHUDColor : MonoBehaviour
    {
        [SerializeField]
        private MixingService mixingService;
        [SerializeField]
        private Image foregroundImage;
        private PaintColor currentPaint;
        void OnEnable()
        {
            this.mixingService.Mixer.MixCompleted += MixCompleted;
        }
        void OnDisable()
        {
            this.mixingService.Mixer.MixCompleted -= MixCompleted;
        }
        void MixCompleted(PaintMixer.MixArgs passArgs)
        {
            StartCoroutine(MixCompletedCoroutine(passArgs));

        }   
        IEnumerator MixCompletedCoroutine(PaintMixer.MixArgs args)
        {
            yield return new WaitForSeconds(0.2f);
            this.foregroundImage.color = args.Result.Color;
            StopCoroutine(MixCompletedCoroutine(args));
        }
        
    }
}
