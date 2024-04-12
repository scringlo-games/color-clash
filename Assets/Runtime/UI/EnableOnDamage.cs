using System.Collections;
using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI
{
    public class EnableOnDamage : MonoBehaviour
    {
        [SerializeField]
        private GameObject target;
        [SerializeField]
        private float maxDuration;
        private float duration;
        [SerializeField]
        private DamageArgsEvent damagedEvent;
        [SerializeField]
        private GameObjectFilterSet filter;
        void OnEnable()
        {
            this.duration = maxDuration;
            damagedEvent.Raised += OnDamaged;
        }
        void OnDisable()
        {   
            damagedEvent.Raised -= OnDamaged;

        }
        void OnDamaged(DamageArgs args)
        {
            Debug.Log("This is Damaged");
            if(this.filter.Evaluate(args.Receiver.gameObject) && args.Amount >= 5f)
            {
                StartCoroutine(EnableObject());
            }
        }
        IEnumerator EnableObject()
        {
            target.SetActive(true);
            yield return new WaitForSeconds(duration);
            target.SetActive(false);
            StopCoroutine(EnableObject());
        }
    }
}
