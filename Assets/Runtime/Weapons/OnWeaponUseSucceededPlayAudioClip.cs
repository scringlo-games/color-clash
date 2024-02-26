using System;
using ScringloGames.ColorClash.Runtime.Audio;
using ScringloGames.ColorClash.Runtime.Weapons.Framework;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    public class OnWeaponUseSucceededPlayAudioClip : MonoBehaviour
    {
        [Header("Audio")]
        [SerializeField]
        private AudioClip clip;
        [Range(-3f, 3f)]
        [SerializeField]
        private float pitchMinimum = 0.75f;
        [Range(-3f, 3f)]
        [SerializeField]
        private float pitchMaximum = 1.25f;
        [Header("Dependencies")]
        [SerializeField]
        private Weapon weapon;
        [SerializeField]
        private AudioService service;
        
        private void OnEnable()
        {
            this.weapon.UseSucceeded += this.OnWeaponUseSucceeded;
        }

        private void OnDisable()
        {
            this.weapon.UseSucceeded -= this.OnWeaponUseSucceeded;
        }

        private void OnWeaponUseSucceeded(WeaponUsedArgs<WeaponContext> args)
        {
            var pitch = Random.Range(this.pitchMinimum, this.pitchMaximum);
            this.service.PlayClipAtPosition(this.clip, this.transform.position, pitch);
        }
    }
}
