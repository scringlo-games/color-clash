using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
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
        void Awake()
        {
            decayFrequencyCurrent = decayFrequency;
            if(TryGetComponent<HealthHandler>(out var handler))
            {
                this.healthHandler = handler;
            }
            if(TryGetComponent<DamageReceiver>(out var receiver))
            {
                this.damageReceiver = receiver;
            }
        }
        void Update()
        {
            if(healthHandler.Health > healthHandler.MaxHealth)
            {
                decayFrequencyCurrent -= Time.deltaTime;
                if(decayFrequencyCurrent <= 0f)
                {
                    decayFrequencyCurrent = decayFrequency;
                    damageReceiver.TakeDamage(this.damageSource,decayAmount);
                    
                }

                


            }
        }
    }
}
