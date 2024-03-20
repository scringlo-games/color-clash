﻿using ScringloGames.ColorClash.Runtime.Conditions;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class OnCollisionEnterApplySlowToOther : OnCollisionEnterApplyConditionToOther
    {
        [FormerlySerializedAs("slowPercent")]
        [Tooltip("The amount by which the other object should be slowed.")]
        [SerializeField]
        private float amount = 1f;

        protected override Condition GetCondition(Collider2D collider2D)
        {
            return new SlowMovementSpeedCondition(this.duration, this.amount);
        }
    }
}
