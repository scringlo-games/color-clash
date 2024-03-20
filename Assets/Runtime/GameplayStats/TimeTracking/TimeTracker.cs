using System;
using TravisRFrench.Common.Runtime.ScriptableEvents;
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
        [SerializeField]
        private ScriptableEvent roomClearedEvent;

        private void OnEnable()
        {
            this.roomClearedEvent.Raised += this.OnRoomCleared;
            this.stopwatch.Start();
        }

        private void OnDisable()
        {
            this.roomClearedEvent.Raised -= this.OnRoomCleared;
            this.stopwatch.Stop();
        }

        private void Update()
        {
            this.stopwatch.Tick(Time.deltaTime);

            if (this.stopwatch.IsRunning)
            {
                this.time.Value = TimeSpan.FromSeconds(this.stopwatch.Time);
            }
        }
        
        private void OnRoomCleared()
        {
            this.stopwatch.Stop();
        }
    }
}
