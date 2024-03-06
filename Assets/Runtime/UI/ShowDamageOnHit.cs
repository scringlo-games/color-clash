using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI
{
    public class ShowDamageOnHit : MonoBehaviour
    {
        [SerializeField]
        private HealthHandler health;
        [SerializeField]
        private GameObject damageIndicatorObject;
        [SerializeField]
        private Color damagedColor;
        [SerializeField]
        private Color healedColor;
        [SerializeField]
        private Vector2 offset;
        private float startHealth;

        private void Awake()
        {
            this.startHealth = this.health.MaxHealth; 
        }

        private void OnEnable()
        {
            this.health.HealthChanged += this.SpawnDamageNumber;

        }

        private void OnDisable()
        {
            this.health.HealthChanged -= this.SpawnDamageNumber;
        }

        private void SpawnDamageNumber(float num)
        {
            var indicatorColor = Color.white;
            var damage = this.startHealth - num;
            if(damage >= 0)//healthhandler has taken damage.
            {
                indicatorColor = this.damagedColor;
            }
            else if (damage <= 0)//healthhandler has healed.
            {
                indicatorColor = this.healedColor;
            }

            this.startHealth -= damage;
            var damageObj = Instantiate(this.damageIndicatorObject,this.transform.position + (Vector3)this.offset, Quaternion.identity);
            if(damageObj.TryGetComponent<DamageNumberSetup>(out var numSetup))
            {
                numSetup.Setup((float)System.Math.Round(damage, 1), indicatorColor);
            }
        }
        
    }
}
