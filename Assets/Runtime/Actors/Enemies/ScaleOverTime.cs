using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace ScringloGames.ColorClash.Runtime
{
    public class ScaleOverTime : MonoBehaviour
    {
        [SerializeField]
        private float scaleTo;
        [SerializeField]
        private float scaleDuration;
        [SerializeField]
        private AnimationCurve animationCurve;
        [SerializeField]
        //must be smaller than scale to 
        private float scaleVariation;
        
        void OnEnable()
        {
            scaleVariation = Random.Range(scaleVariation * -1f, scaleVariation);
            scaleTo += scaleVariation;

            this.transform
            .DOScale(this.transform.localScale * this.scaleTo, this.scaleDuration)
            .SetEase(this.animationCurve);
        }
    }
}
