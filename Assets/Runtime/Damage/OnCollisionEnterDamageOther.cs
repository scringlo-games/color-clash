using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Damage
{
    public class OnCollisionEnterDamageOther : MonoBehaviour
    {
        [SerializeField]
        private GameObjectFilterSet filter;
        [SerializeField]
        [Tooltip("The amount of damage to inflict to the other object.")]
        private int damageToInflict;
        [Tooltip("The DamageSource that is inflicting this damage.")]
        [SerializeField]
        private DamageSource damageSource;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var other = collision.collider;

            if (!this.filter.Evaluate(other.gameObject))
            {
                return;
            }

            var damageReceiver = other.GetComponent<DamageReceiver>();

            if (damageReceiver == null)
            {
                return;
            }
            
            damageReceiver.TakeDamage(this.damageSource, this.damageToInflict);
        }
    }
}
