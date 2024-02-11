using System;
using System.Collections.Generic;
using System.Linq;

namespace ScringloGames.ColorClash.Runtime.Mixing
{
    public class PaintMixer
    {
        public enum MixState
        {
            Empty,
            Mixing,
            Mixed,
        }

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
        public MixState State { get; private set; }

        public PaintMixer AddColor(PaintColor color)
        {
            this.UpdateCurrentState();
            
            switch (this.State)
            {
                case MixState.Empty:
                    this.palette.Add(color);
                    this.UpdateCurrentState();
                    this.NotifyMixStarted();
                    break;
                case MixState.Mixing:
                    this.palette.Add(color);
                    this.UpdateCurrentState();
                    this.NotifyMixCompleted();
                    break;
                case MixState.Mixed:
                    this.palette.Clear();
                    this.UpdateCurrentState();
                    this.AddColor(color);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
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

        private void UpdateCurrentState()
        {
            this.State = this.palette.Count switch
            {
                0 => MixState.Empty,
                1 => MixState.Mixing,
                2 => MixState.Mixed,
            };
        }
        
        private void NotifyMixStarted()
        {
            var args = new MixArgs()
            {
                First = this.palette.FirstOrDefault(),
                Second = this.palette.LastOrDefault(),
                Result = this.GetResult(),
            };
            
            this.MixStarted?.Invoke(args);
            this.State = MixState.Empty;
        }
        
        private void Continue()
        {
            var args = new MixArgs()
            {
                First = this.palette.FirstOrDefault(),
                Second = this.palette.LastOrDefault(),
                Result = this.GetResult(),
            };
            
            this.MixStarted?.Invoke(args);
            this.State = MixState.Mixing;
        }

        private void NotifyMixCancelled()
        {
            var args = new MixArgs()
            {
                First = this.palette.FirstOrDefault(),
                Second = this.palette.LastOrDefault(),
                Result = this.GetResult(),
            };
            
            this.MixCancelled?.Invoke(args);
        }

        private void NotifyMixCompleted()
        {
            var args = new MixArgs()
            {
                First = this.palette.FirstOrDefault(),
                Second = this.palette.LastOrDefault(),
                Result = this.GetResult(),
            };
            
            this.MixCompleted?.Invoke(args);
            this.State = MixState.Mixed;
        }
    }
}
