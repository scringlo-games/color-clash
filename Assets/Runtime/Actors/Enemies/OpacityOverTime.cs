using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class OpacityOverTime : MonoBehaviour
    {
        [SerializeField]
        [Range(0,1)]
        private float opacityTo;
        [SerializeField]
        private float opacityDuration;
        [SerializeField]
        private AnimationCurve animCurve;
        [SerializeField]
        private SpriteRenderer sprite;
    
     
        void OnEnable()
        {
            this.sprite
            .DOFade(this.opacityTo, this.opacityDuration)
            .SetEase(this.animCurve);
        }
    }
}
