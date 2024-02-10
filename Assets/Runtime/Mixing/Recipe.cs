using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Mixing
{
    [Serializable]
    public class Recipe
    {
        [field: SerializeField]
        public PaintColor FirstInput { get; set; }
        [field: SerializeField]
        public PaintColor SecondInput { get; set; }
        [field: SerializeField]
        public PaintColor Output { get; set; }
    }
}
