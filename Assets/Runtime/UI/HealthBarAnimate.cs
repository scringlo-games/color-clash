using DG.Tweening;
using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime
{
    public class HealthBarAnimate : MonoBehaviour
    {
        [SerializeField]
        private Image targetImage;
        [SerializeField]
        private DamageArgsEvent damageArgsEvent;
        [SerializeField]
        private GameObjectFilterSet filter;
        [SerializeField]
        private float animateDuration;
        [SerializeField]
        private AnimationCurve animCurve;
        [SerializeField]
        private HealthHandler healthHandler;
        private float maxHealth;
        private float fillAmount;
        private GameObject targetObject;
        void OnEnable()
        {
            damageArgsEvent.Raised += OnDamaged;
        }
        void OnDisable()
        {
            damageArgsEvent.Raised -= OnDamaged;
        }
        void OnDamaged(DamageArgs args)
        {
            DOTween.CompleteAll();
            targetObject = args.Receiver.gameObject;
            if (this.filter.Evaluate(targetObject))
            {
                //healthHandler = targetObject.GetComponent<HealthHandler>();
                fillAmount = healthHandler.Health/healthHandler.MaxHealth;
                targetImage
                .DOFillAmount(fillAmount, animateDuration)
                .SetEase(animCurve);
            }
        }

    
    }
}
