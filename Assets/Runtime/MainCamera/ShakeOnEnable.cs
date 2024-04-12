using DG.Tweening;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.MainCamera
{
    public class ShakeOnEnable : MonoBehaviour
    {
        [SerializeField]
        private GameObject target; 
        [SerializeField]
        private float shakeRotation;
        [SerializeField]
        private float shakeDuration;
        [SerializeField]
        private int numberOfShakes;
        [SerializeField]
        private AnimationCurve shakeCurve;
        void OnEnable()
        {
            Vector3 rotateVector = new Vector3(0f, 0f, shakeRotation);
            target.transform
                .DORotate(rotateVector, shakeDuration)
                .SetEase(shakeCurve)
                .SetLoops(numberOfShakes);
        }
        void OnDisable()
        {
            target.transform.DOPause();
        }
    
    }
}
