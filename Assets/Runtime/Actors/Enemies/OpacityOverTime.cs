using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime.Actors.Enemies
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
        [SerializeField]
        private Image image;
    
     
        void OnEnable()
        {
            if(sprite != null)
            {
                this.sprite
                .DOFade(this.opacityTo, this.opacityDuration)
                .SetEase(this.animCurve);
            }
            else if(sprite != null)
            {
                this.image
                .DOFade(this.opacityTo, this.opacityDuration)
                .SetEase(this.animCurve);
            }
        }
    }
}
