using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Mixing
{
    [CreateAssetMenu(menuName = "Scriptables/Paint Color")]
    public class PaintColor : ScriptableObject
    {
        [SerializeField]
        private string displayName;
        [SerializeField]
        private Color color = Color.white;

        public string DisplayName
        {
            get => this.displayName;
            set => this.displayName = value;
        }
        public Color Color
        {
            get => this.color;
            set => this.color = value;
        }
    }
}
