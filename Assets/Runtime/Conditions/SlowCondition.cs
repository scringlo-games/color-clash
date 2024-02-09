using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class SlowCondition : Condition
    {
        private float slowPercent;
        private MoveToGameObject moveToGameObject;

        /// <summary>
        /// Percent speed after slow. Read only.
        /// </summary>
        public float SlowPercent
        {
            get { return this.slowPercent; }
        }
        
        //If percent is too big/small, clamp to reasonable range.
        public SlowCondition(float slowPercent)
        {
            slowPercent = Mathf.Clamp01(slowPercent);
            this.slowPercent = slowPercent;
        }

        /// <summary>
        /// Instance with set duration.
        /// </summary>
        /// <param name="slowPercent">Percent speed after slow.</param>
        /// <param name="Duration">How long it lasts.</param>
        public SlowCondition(float slowPercent, float Duration)
        {
            this.Duration = Duration;
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
    }
}
