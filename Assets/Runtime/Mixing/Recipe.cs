using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Mixing
{
    [Serializable]
    public class Recipe
    {
        [field: SerializeField]
        public PaintColor FirstInputColor { get; set; }
        [field: SerializeField]
        public PaintColor SecondInputColor { get; set; }
        [field: SerializeField]
        public PaintColor OutputColor { get; set; }
    }
}
