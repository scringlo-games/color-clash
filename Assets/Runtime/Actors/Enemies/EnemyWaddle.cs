using DG.Tweening;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Actors.Enemies
{
    public class EnemyWaddle : MonoBehaviour
    {
        [SerializeField]
        private GameObject spriteParentObject;
        [SerializeField] 
        private float rotateDeg;
        [SerializeField]
        private float duration;
        [SerializeField]
        private AnimationCurve animCurve;
        void OnEnable()
        {
            Vector3 rotateVector = new Vector3(spriteParentObject.transform.rotation.x, spriteParentObject.transform.rotation.y, rotateDeg);
            this.spriteParentObject.transform
                .DORotate(rotateVector, duration)
                .SetEase(animCurve)
                .SetLoops(-1, LoopType.Restart);  
        }
        void OnDisable()
        {
            spriteParentObject.transform.DOPause();
            spriteParentObject.transform.rotation = Quaternion.identity;
            
        }
        
    }
}
