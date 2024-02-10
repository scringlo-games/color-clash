using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime.UI.ColorMixingHUD
{
    public class ColorMixingHUDNode : MonoBehaviour
    {
        [SerializeField]
        private RectTransform rectTransform;
        [SerializeField]
        private Image imageToColorize;
        [SerializeField]
        private CanvasGroup canvasGroup;
        private Vector2 startingPosition;

        private void Awake()
        {
            this.startingPosition = this.rectTransform.anchoredPosition;
        }

        public void Center()
        {
            this.rectTransform.anchoredPosition = Vector2.zero;
        }

        public void ReturnToStartingPosition()
        {
            this.rectTransform.anchoredPosition = this.startingPosition;
        }
        
        public TweenerCore<Vector3, Vector3, VectorOptions> PushLeft()
        {
            return this.rectTransform
                .DOLocalMoveX(this.startingPosition.x, 1f)
                .From(Vector2.zero);
        }

        public TweenerCore<float, float, FloatOptions> FadeIn()
        {
            return this.canvasGroup
                .DOFade(1f, 1f)
                .From(0f);
        }

        public TweenerCore<float, float, FloatOptions> FadeOut()
        {
            return this.canvasGroup
                .DOFade(0f, 1f)
                .From(1f);
        }

        public void SetColor(Color color)
        {
            this.imageToColorize.color = color;
        }
    }
}