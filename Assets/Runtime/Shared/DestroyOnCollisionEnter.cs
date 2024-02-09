using System.Collections;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public abstract class DestroyOnCollisionEnter : MonoBehaviour
    {
        [Tooltip("The filter the other object must pass in order to apply these effects.")]
        [SerializeField]
        private GameObjectFilterSet filter;
        [Tooltip("The delay in seconds to wait before destroying the object.")]
        [SerializeField]
        private float delay = 0.05f;

        protected abstract GameObject GetDestroyTarget(Collision2D collision);
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var other = collision.collider;

            if (!this.filter.Evaluate(other.gameObject))
            {
                return;
            }

            var destroyTarget = this.GetDestroyTarget(collision);
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
