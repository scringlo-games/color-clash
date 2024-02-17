using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.Attacks
{
    public class MeleeAttackBehaviour : AttackBehaviour
    {
        [Header("Hit Box")]
        [SerializeField]
        private GameObject hitBox;
        [SerializeField]
        private float hitBoxActiveDuration = 0.15f;
        
        protected override void OnAttack()
        {
            this.hitBox.SetActive(true);
            this.StartCoroutine(this.HideHitBoxAfterDelay());
        }

        private IEnumerator HideHitBoxAfterDelay()
        {
            yield return new WaitForSeconds(this.hitBoxActiveDuration);

            this.hitBox.SetActive(false);
        }
    }
}
