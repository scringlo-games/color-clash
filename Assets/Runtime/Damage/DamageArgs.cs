﻿using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Damage
{
    public class DamageArgs
    {
        public GameObject Originator { get; set; }
        public IDamageSource Source { get; set; }
        public DamageReceiver Receiver { get; set; }
        public float Amount { get; set; }
    }
}