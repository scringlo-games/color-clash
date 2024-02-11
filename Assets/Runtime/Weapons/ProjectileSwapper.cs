using System;
using System.Linq;
using ScringloGames.ColorClash.Runtime.Mixing;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    public class ProjectileSwapper : MonoBehaviour
    {
        [Serializable]
        private struct Entry
        {
            public PaintColor PaintColor;
            public GameObject ProjectilePrefab;
        }

        [SerializeField]
        private MixingService mixingService;
        [SerializeField]
        private ProjectileLauncher launcher;
        [FormerlySerializedAs("projectiles")]
        [SerializeField]
        private Entry[] entries;

        private void OnEnable()
        {
            this.mixingService.Mixer.MixCompleted += this.OnMixCompleted;
        }

        private void OnDisable()
        {
            this.mixingService.Mixer.MixCompleted -= this.OnMixCompleted;
        }

        private void OnMixCompleted(PaintMixer.MixArgs args)
        {
            var colorToSwapTo = args.Result;
            var firstMatchingEntry = this.entries
                .Where(entry => entry.PaintColor == colorToSwapTo)
                .Cast<Entry?>()
                .FirstOrDefault();

            if (firstMatchingEntry == null)
            {
                Debug.LogError(
                    $"The color {colorToSwapTo} was not found in {this.name} (is it missing an entry?)");
                return;
            }

            this.launcher.ObjectToLaunch = firstMatchingEntry.Value.ProjectilePrefab;
        }
    }
}
