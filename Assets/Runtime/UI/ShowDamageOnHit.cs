using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
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
        void Awake()
        {
           startHealth = health.MaxHealth; 
        }
        void OnEnable()
        {
            health.HealthChanged += SpawnDamageNumber;

        }
        void OnDisable()
        {
            health.HealthChanged -= SpawnDamageNumber;
        }
        void SpawnDamageNumber(float num)
        {
            Color indicatorColor = Color.white;
            float damage = startHealth - num;
            if(damage >= 0)//healthhandler has taken damage.
            {
                indicatorColor = damagedColor;
            }
            else if (damage <= 0)//healthhandler has healed.
            {
                indicatorColor = healedColor;
            }
            startHealth -= damage;
            GameObject damageObj = Instantiate(damageIndicatorObject,this.transform.position + (Vector3)offset, Quaternion.identity);
            if(damageObj.TryGetComponent<DamageNumberSetup>(out var numSetup))
            {
                numSetup.Setup(damage, indicatorColor);
            }
        }
        
    }
}
