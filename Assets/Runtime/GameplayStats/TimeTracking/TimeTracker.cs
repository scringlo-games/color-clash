using System;
using TravisRFrench.Common.Runtime.Timing;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.GameplayStats.TimeTracking
{
    public class TimeTracker : MonoBehaviour
    {
        [SerializeField]
        private Stopwatch stopwatch;
        [SerializeField]
        private TimeSpanVariable time;

        private void OnEnable()
        {
            this.stopwatch.Start();
        }

        private void OnDisable()
        {
            this.stopwatch.Stop();
        }

        private void Update()
        {
            this.stopwatch.Tick(Time.deltaTime);
            this.time.Value = TimeSpan.FromSeconds(this.stopwatch.Time);
        }
    }
}
