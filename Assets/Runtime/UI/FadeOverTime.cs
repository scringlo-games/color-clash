using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime.UI
{
    public class FadeOverTime : MonoBehaviour
    {
        [SerializeField]
        private Image target;
        [SerializeField]
        private float duration;
        [SerializeField]
        private float fadeTo;
        [SerializeField]
        private AnimationCurve animCurve;
        void OnEnable()
        {
            target.color = Color.white;
            target
            .DOFade(fadeTo, duration)
            .SetEase(animCurve);
        }
        void OnDisable()
        {
            target.DOPause();
        }
        
    }
}
