using DG.Tweening;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.InputPromptHUD
{
    public class InputPromptDrawer : MonoBehaviour
    {
        [SerializeField]
        private GameObject container;
        [SerializeField]
        private CanvasGroup canvasGroup;
        [SerializeField]
        private float inDuration = 1f;
        [SerializeField]
        private Ease inEase = Ease.Linear;
        [SerializeField]
        private float outDuration = 1f;
        [SerializeField]
        private Ease outEase = Ease.Linear;
        
        public void Show()
        {
            this.canvasGroup.alpha = 0f;
            this.container.SetActive(true);
            
            this.canvasGroup
                .DOFade(1f, this.inDuration)
                .SetEase(this.inEase);
        }

        public void Hide()
        {
            this.canvasGroup
                .DOFade(0f, this.outDuration)
                .SetEase(this.outEase)
                .OnComplete(() => this.container.SetActive(false));
        }
    }
}
