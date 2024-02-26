using System;
using DG.Tweening;
using ScringloGames.ColorClash.Runtime.Damage;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class OnDamageTakenFlinch : MonoBehaviour
    {
        [Serializable]
        private record ShakeAnimationArgs
        {
            public Ease Ease = Ease.InOutBounce;
            public float Duration = 1f;
            public float Magnitude = 1f;
            public int Vibrato = 10;
            public float Randomness = 90f;
            public bool Snapping = false;
            public bool FadeOut = true;
            public ShakeRandomnessMode RandomnessMode = ShakeRandomnessMode.Full;
        }

        [Serializable]
        private record ColorizeAnimationArgs
        {
            public float Duration = 1f;
            public Color Color = Color.red;
            public Ease Ease = Ease.InOutFlash;
        }

        [FormerlySerializedAs("duration")]
        [Header("Animation")]
        [SerializeField]
        private ShakeAnimationArgs shakeAnimation;
        [SerializeField]
        private ColorizeAnimationArgs colorizeAnimation;
        [Header("Components")]
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [Header("Events")]
        [SerializeField]
        private DamageArgsEvent damagedEvent;
        private Sequence sequence;
        
        private void OnEnable()
        {
            this.damagedEvent.Raised += this.OnDamaged;
        }

        private void OnDisable()
        {
            this.damagedEvent.Raised -= this.OnDamaged;
        }

        private void OnDamaged(DamageArgs args)
        {
            if (args.Receiver.gameObject != this.gameObject)
            {
                return;
            }

            if (this.sequence != null && this.sequence.IsPlaying())
            {
                this.sequence.Complete();
            }
            
            var shakeTween = this.spriteRenderer.transform
                .DOShakePosition(
                    this.shakeAnimation.Duration, 
                    this.shakeAnimation.Magnitude, 
                    this.shakeAnimation.Vibrato, 
                    this.shakeAnimation.Randomness, 
                    this.shakeAnimation.Snapping, 
                    this.shakeAnimation.FadeOut, 
                    this.shakeAnimation.RandomnessMode)
                .SetEase(this.shakeAnimation.Ease);

            var colorizeTween = this.spriteRenderer
                .DOColor(
                    this.colorizeAnimation.Color,
                    this.colorizeAnimation.Duration / 2f)
                .SetEase(this.colorizeAnimation.Ease)
                .SetLoops(2, LoopType.Yoyo);

            this.sequence = DOTween.Sequence()
                .Insert(0, shakeTween)
                .Insert(0, colorizeTween);
        }
    }
}
