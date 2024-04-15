using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class BossBreatheTween : MonoBehaviour
    {
       [SerializeField]
       private GameObject bossHead;
       [SerializeField]
       private float breathIntensity = 0.5f;
       [SerializeField]
       private float breathDuration = 1f;
       [SerializeField]
       private AnimationCurve animCurve;
       void OnEnable()
       {
            bossHead.transform.DOLocalMoveY(breathIntensity, breathDuration)
            .SetEase(animCurve)
            .SetLoops(-1, LoopType.Restart); 
       }
    }
}
