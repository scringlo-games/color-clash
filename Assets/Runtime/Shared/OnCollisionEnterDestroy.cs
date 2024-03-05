using System.Collections;
using ScringloGames.ColorClash.Runtime.Shared.Contact;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public abstract class OnCollisionEnterDestroy : ContactBehaviour
    {
        [Tooltip("The filter the other object must pass in order to apply these effects.")]
        [SerializeField]
        private GameObjectFilterSet filter;
        [Tooltip("The delay in seconds to wait before destroying the object.")]
        [SerializeField]
        private float delay = 0.05f;

        protected abstract GameObject GetDestroyTarget(Collision2D collision);

        public override void OnCollisionEntered(Collision2D collision2D)
        {
            var other = collision2D.collider;

            if (!this.filter.Evaluate(other.gameObject))
            {
                return;
            }

            var destroyTarget = this.GetDestroyTarget(collision2D);
            this.StartCoroutine(this.DestroyObjectAfterSeconds(destroyTarget, this.delay));
        }

        private IEnumerator DestroyObjectAfterSeconds(GameObject other, float seconds)
        {
            yield return new WaitForSeconds(seconds);

            var destructible = other.GetComponent<Destructible>();
            destructible.Destroy();
        }
    }
}
