using ScringloGames.ColorClash.Runtime.GameServices;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Mixing
{
    [CreateAssetMenu(menuName = "Scriptables/Game Services/Mixing Service")]
    public class MixingService : GameService
    {
        [SerializeField]
        private ColorTable table;
        [SerializeField]
        private RecipeBook book;

        public ColorTable Table => this.table;
        public PaintMixer Mixer { get; private set; }

        public override void Setup()
        {
            this.Mixer = new PaintMixer(this.book);
        }
    }
}
