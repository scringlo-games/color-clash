using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class PlaySoundOnDamaged : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        private float pitchVariation;
        [SerializeField]
        private bool syncDamageToPitch;
        [SerializeField]
        private DamageArgsEvent damageArgs; 
        [SerializeField]
        private GameObjectFilterSet filter;
        void OnEnable()
        {
            damageArgs.Raised += OnDamaged;
        }
        void OnDisable()
        {
            damageArgs.Raised -= OnDamaged;
        }   
        void OnDamaged(DamageArgs args)
        {
            if(filter.Evaluate(args.Receiver.gameObject) && args.Amount >= 1f)
            {
                if(syncDamageToPitch)
                {
                    audioSource.pitch = Random.Range(-pitchVariation, pitchVariation) + (1.2f - ((args.Amount-5f)/30f));

                }
                else
                {
                    audioSource.pitch += Random.Range(-pitchVariation, pitchVariation);
                }
                    audioSource.Play();
            }
        }
    }
}
