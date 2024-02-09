using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class SlowCondition : Condition
    {
        private float slowPercent;
        private MoveToGameObject moveToGameObject;

        /// <param name="duration">The duration of the condition in seconds.</param>
        /// <param name="slowPercent">Percent speed after slow.</param>
        public SlowCondition(float duration, float slowPercent)
            : base(duration)
        {
            slowPercent = Mathf.Clamp01(slowPercent);
            this.slowPercent = slowPercent;
        }

        public override void OnApplied(ConditionBank bank)
        {
            if (bank == null)
            {
                return;
            }
            
            this.moveToGameObject = bank.GetComponent<MoveToGameObject>();

            if (this.moveToGameObject == null)
            {
                return;
            }
            
            this.moveToGameObject.Velocity *= this.slowPercent;
        }

        public override void OnExpired(ConditionBank bank)
        {
            this.moveToGameObject.Velocity /= this.slowPercent;
        }

        public override Condition Clone()
        {
            return new SlowCondition(this.Duration, this.slowPercent);
        }
    }
}
