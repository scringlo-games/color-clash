using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Actors.PlayerCharacter
{
    public class PlayerOverheaDecay : MonoBehaviour
    {
        [SerializeField][Range(0,1)]
        private float decayFrequency;
        [SerializeField][Range(0,5)]
        private float decayAmount;
        [SerializeField]
        private DamageSource damageSource;
        private float decayFrequencyCurrent;
        private HealthHandler healthHandler;
        private DamageReceiver damageReceiver;

        private void Awake()
        {
            this.decayFrequencyCurrent = this.decayFrequency;
            if(this.TryGetComponent<HealthHandler>(out var handler))
            {
                this.healthHandler = handler;
            }
            if(this.TryGetComponent<DamageReceiver>(out var receiver))
            {
                this.damageReceiver = receiver;
            }
        }

        private void Update()
        {
            if(this.healthHandler.Health > this.healthHandler.MaxHealth)
            {
                this.decayFrequencyCurrent -= Time.deltaTime;
                if(this.decayFrequencyCurrent <= 0f)
                {
                    this.decayFrequencyCurrent = this.decayFrequency;
                    this.damageReceiver.TakeDamage(this.damageSource, this.decayAmount);
                    
                }

                


            }
        }
    }
}
