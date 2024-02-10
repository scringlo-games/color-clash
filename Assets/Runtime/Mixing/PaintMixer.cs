using System;
using System.Collections.Generic;
using System.Linq;

namespace ScringloGames.ColorClash.Runtime.Mixing
{
    public class PaintMixer
    {
        public class MixArgs
        {
            public PaintColor First;
            public PaintColor Second;
            public PaintColor Result;
        }
        
        private readonly RecipeBook book;
        private readonly List<PaintColor> palette;

        public PaintMixer(RecipeBook book)
        {
            this.book = book;
            this.palette = new List<PaintColor>();
        }

        public event Action<MixArgs> MixStarted;
        public event Action<MixArgs> MixCancelled;
        public event Action<MixArgs> MixCompleted;

        public PaintMixer AddColor(PaintColor color)
        {
            if (this.palette.Count >= 2)
            {
                const string message = "Cannot mix more than two colors at once; clear the palette and try again.";
                throw new InvalidOperationException(message);
            }

            this.palette.Add(color);
            
            var args = new MixArgs()
            {
                First = this.palette.FirstOrDefault(),
                Second = this.palette.LastOrDefault(),
                Result = this.GetResult(),
            };
            
            switch (this.palette.Count)
            {
                case 0:
                    this.MixStarted?.Invoke(args);
                    break;
                case 1:
                    break;
                case 2:
                    this.MixCompleted?.Invoke(args);
                    break;
            }

            return this;
        }

        public PaintMixer ClearAllColors()
        {
            this.palette.Clear();
            
            var args = new MixArgs()
            {
                First = this.palette.FirstOrDefault(),
                Second = this.palette.LastOrDefault(),
                Result = null,
            };
            this.MixCancelled?.Invoke(args);
            
            return this;
        }
        
        public PaintColor GetResult()
        {
            var hashSet = new HashSet<PaintColor>(this.palette);
            
            foreach (var recipe in this.book.Recipes)
            {
                var areMatch = hashSet.SetEquals(new[] { recipe.FirstInput, recipe.SecondInput });

                if (areMatch)
                {
                    return recipe.Output;
                }
            }

            return null;
        }
    }
}
