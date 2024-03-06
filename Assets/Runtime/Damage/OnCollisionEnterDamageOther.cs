using ScringloGames.ColorClash.Runtime.Shared.Contact;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Damage
{
    public class OnCollisionEnterDamageOther : ContactBehaviour
    {
        [SerializeField]
        private GameObjectFilterSet filter;
        [SerializeField]
        [Tooltip("The amount of damage to inflict to the other object.")]
        private int damageToInflict;
        [Tooltip("The DamageSource that is inflicting this damage.")]
        [SerializeField]
        private DamageSource damageSource;

        public override void OnCollisionEntered(Collision2D collision2D)
        {
            var other = collision2D.collider;
            this.DamageOther(other);
        }

        public override void OnTriggerEntered(Collider2D collider2D)
        {
            this.DamageOther(collider2D);
        }

        private void DamageOther(Collider2D other)
        {
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
