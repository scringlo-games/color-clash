using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.PainSplatter;
using ScringloGames.ColorClash.Runtime.PlayerCharacter;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    /// <summary>
    /// Damageless projectile abstract. Customize by overriding ApplyProjectileEffect.
    /// </summary>
    public abstract class ProjectileHitScript : MonoBehaviour
    {
        [SerializeField] private CreateDecalOnDestroying tempSpawner;
        private float pitchVariation = 0.2f;
        
        public void OnCollisionEnter2D(Collision2D collision)
        {
            //We don't want paint hurting the player.
            if (collision.gameObject.GetComponent<PlayerInputHandler>() != null)
            {
                if (this.TryGetComponent(out AudioSource audioSource))
                {
                    audioSource.pitch = (this.pitchVariation * Random.value) + 1.0f;
                    audioSource.Play();
                }
                
                return;
            }
            
            //If it can take effects or damage, projectiles should affect it.
            if (collision.gameObject.GetComponent<ConditionBank>() != null) 
            {
                this.ApplyProjectileEffects(collision.gameObject);
            }

            if (collision.gameObject.GetComponent<HealthHandler>() != null)
            {
                this.IfHasHealth(collision.gameObject);
            }
        }

        private void OnDisable()
        {
            this.tempSpawner.CreateNewSprite(this.transform.position);
        }
        
        /// <summary>
        /// Override with projectile effects.
        /// </summary>
        /// <param name="otherGameObject">What this affects.</param>
        protected abstract void ApplyProjectileEffects(GameObject otherGameObject);
        
        /// <summary>
        /// Override.
        /// </summary>
        /// <param name="otherGameObject">What this affects.</param>
        protected abstract void IfHasHealth(GameObject otherGameObject);
    }
}
