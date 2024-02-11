﻿using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Damage
{
    public class DamageSource : MonoBehaviour
    {
        [SerializeField]
        private GameObject originator;
        
        public GameObject Originator
        {
            get => this.originator;
            set => this.originator = value;
        }
    }
}
