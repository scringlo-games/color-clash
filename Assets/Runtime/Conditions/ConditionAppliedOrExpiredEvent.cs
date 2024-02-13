using TravisRFrench.Common.Runtime.ScriptableEvents;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    [CreateAssetMenu(menuName = "Scriptables/Events/Condition Applied Or Expired")]
    public class ConditionAppliedOrExpiredEvent : ScriptableEvent<ConditionAppliedOrExpiredEvent.ConditionAppliedOrExpiredEventArgs>
    {
        public class ConditionAppliedOrExpiredEventArgs
        {
            public ConditionBank ConditionBank { get; set; }
            public Condition Condition { get; set; }
        }
    }
}
