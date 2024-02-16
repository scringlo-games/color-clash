using System.Collections;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Attacks
{
    public class MeleeAttackBehaviour : AttackBehaviour
    {
        [SerializeField]
        private GameObject hitBox;
        [SerializeField]
        private float activeDuration = 0.15f;
        
        protected override void OnAttack()
        {
            this.hitBox.SetActive(true);
            this.StartCoroutine(this.HideHitBoxAfterDelay());
        }

        private IEnumerator HideHitBoxAfterDelay()
        {
            yield return new WaitForSeconds(this.activeDuration);

            this.hitBox.SetActive(false);
        }
    }
}
