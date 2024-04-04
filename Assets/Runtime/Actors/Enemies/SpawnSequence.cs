using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class SpawnSequence : MonoBehaviour
    {
        [SerializeField]
        private GameObject bodyGraphics;
        [SerializeField]
        private GameObject puddleGraphics;
        [SerializeField]
        private GameObject ballGraphics;
        [SerializeField]
        private float puddleScale = 0.5f;
        [SerializeField]
        private float seqDuration= 1f;
        [SerializeField] 
        private AnimationCurve sequenceCurve;

        void OnEnable()
        {
            bodyGraphics.SetActive(false);

            var puddleTween = puddleGraphics.transform.DOScale(puddleScale, seqDuration)
            .SetEase(sequenceCurve);
            
            var ballTween = ballGraphics.transform.DOLocalMove(Vector3.zero, seqDuration)
            .SetEase(sequenceCurve);   
            var ballScaleTween = ballGraphics.transform.DOScale(puddleScale, seqDuration)
            .SetEase(sequenceCurve);

            DOTween.Sequence()
            .Insert(0f, puddleTween)
            .Insert(0f, ballTween)
            .Insert(0f, ballScaleTween)
            .OnComplete(TweenComplete);
            
                  
        }
        void TweenComplete()
        {
            bodyGraphics.SetActive(true);
            puddleGraphics.SetActive(false);
            ballGraphics.SetActive(false);
        }
        
    }
}
