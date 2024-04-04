using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
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

        public void JumpToCenter()
        {
            this.rectTransform.anchoredPosition = Vector2.zero;
        }

        public void JumpToStartingPosition()
        {
            this.rectTransform.anchoredPosition = this.startingPosition;
        }

        public TweenerCore<Vector3, Vector3, VectorOptions> MergeToCenter()
        {
            return this.rectTransform
                .DOLocalMoveX(0f, 0.2f)
                .From(this.startingPosition);
        }

        public TweenerCore<Vector3, Vector3, VectorOptions> PushLeft()
        {
            return this.rectTransform
                .DOLocalMoveX(this.startingPosition.x, 0.1f)
                .From(Vector2.zero);
        }

        public TweenerCore<float, float, FloatOptions> FadeIn()
        {
            return this.canvasGroup
                .DOFade(1f, 0.1f)
                .From(0f);
        }

        public TweenerCore<float, float, FloatOptions> FadeOut()
        {
            return this.canvasGroup
                .DOFade(0f, 0.1f)
                .From(1f);
        }

        public void SetColor(Color color)
        {
            this.imageToColorize.color = color;
        }
    }
}