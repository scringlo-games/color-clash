using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class SlowCondition : Condition
    {
        public float slowPercent;
        private MoveToGameObject moveToGameObject;
        
        //If percent is too big/small, clamp to reasonable range.
        public SlowCondition(float slowPercent)
        {
            slowPercent = Mathf.Clamp01(slowPercent);
            this.slowPercent = slowPercent;
        }

        public override void OnApplied(ConditionBank bank)
        {
            moveToGameObject = bank.GetComponent<MoveToGameObject>();
            moveToGameObject.Velocity *= slowPercent;
        }

        public override void OnExpired(ConditionBank bank)
        {
            moveToGameObject.Velocity /= slowPercent;
        }
    }
}
