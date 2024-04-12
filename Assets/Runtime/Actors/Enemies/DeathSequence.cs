using DG.Tweening;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Actors.Enemies
{
    public class DeathSequence : MonoBehaviour
    {   [Header("Splatter Behavior")]

        [SerializeField]
        private SpriteRenderer splatterSprite;
        [SerializeField]
        private GameObject splatterObject;
        [SerializeField]
        private float splatterScaleTo;
        [SerializeField]
        [Range(0f,1f)]
        private float splatterOpacityTo;
        [SerializeField]
        private float splatterDuration;
        [SerializeField]
        private AnimationCurve splatterCurve;

        [Header("Ball Behavior")]
        [SerializeField]
        private GameObject ballObject;
        [SerializeField]
        private SpriteRenderer ballSprite;
        [SerializeField]
        [Range(0f,1f)]
        private float ballOpacityTo;
        [SerializeField]
        private float ballScaleTo;
        [SerializeField]
        private float ballFallDuration;
        [SerializeField]
        private float ballSquishDuration;
        [SerializeField]
        private AnimationCurve ballFallCurve;
        [SerializeField]
        private AnimationCurve ballSquishCurve;
        
        void OnEnable()
        {
            var scaleTween = this.transform
                .DOScale(this.splatterScaleTo, this.splatterDuration)
                .SetEase(this.splatterCurve);
                
            var splatterFadeTween = this.splatterSprite
                .DOFade(this.splatterOpacityTo, this.splatterDuration)
                .SetEase(this.splatterCurve);

            var ballMoveTween = this.ballObject.transform
                .DOLocalMove(Vector2.zero, this.ballFallDuration)
                .SetEase(ballFallCurve);
            var ballFadeTween = this.ballSprite
                .DOFade(ballOpacityTo, ballSquishDuration)
                .SetEase(ballSquishCurve);
            var ballSquishTween = this.ballObject.transform
                .DOScale(ballScaleTo,ballSquishDuration)
                .SetEase(ballSquishCurve);
                
                
                
            DOTween.Sequence()
                .Insert(0, ballMoveTween)
                .Insert(ballFallDuration, ballFadeTween)
                .Insert(ballFallDuration, ballSquishTween)
                .Insert(ballFallDuration, scaleTween)
                .Insert(ballFallDuration, splatterFadeTween);
            
        }
    }
}
