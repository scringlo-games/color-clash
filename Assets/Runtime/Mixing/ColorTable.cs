using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Mixing
{
    [CreateAssetMenu(menuName = "Scriptables/Color Table")]
    public class ColorTable : ScriptableObject
    {
        [field: SerializeField]
        public PaintColor Red { get; set; }
        [field: SerializeField]
        public PaintColor Blue { get; set; }
        [field: SerializeField]
        public PaintColor Yellow { get; set; }
    }
}
