using System;
using ScringloGames.ColorClash.Runtime.Attacks;
using ScringloGames.ColorClash.Runtime.Movement;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public class FoamFistAIBrain : MonoBehaviour
    {
        [SerializeField]
        private GameObject target;
        [SerializeField]
        private DestinationMover mover;
        [SerializeField]
        private AttackBehaviour attackBehaviour;
        [FormerlySerializedAs("MaxMoveSpeed")] [SerializeField] 
        private float MaxDistMoveSpeed;
        [FormerlySerializedAs("MinMoveSpeed")] [SerializeField] 
        private float MinDistMoveSpeed;

        /// <summary>
        /// Beyond this distance, min move speed.
        /// </summary>
        [SerializeField] private float FarSpeedUpDistance;

        /// <summary>
        /// At this distance or closer, max move speed.
        /// </summary>
        [SerializeField] private float NearSpeedUpDistance;
        //Difference between Far and Near distance, or the range.
        private float SpeedUpDifferenceDist;
        //Difference between Far and Near speeds.
        private float SpeedUpDifferenceSpeed;
        
        [SerializeField]
        private DirectionalMover directionalMover;
        [SerializeField]
        private float attackDistance = 1f;

        [SerializeField] private float cooldownDuration = 1f;

        private float cooldownTimer;
        
        private void OnEnable()
        {
            this.target = GameObject.FindWithTag("Player");
            this.cooldownTimer = 0;
            
            //Math that creates variables for easy use
            this.SpeedUpDifferenceDist = this.FarSpeedUpDistance - this.NearSpeedUpDistance;
            this.SpeedUpDifferenceSpeed = this.MaxDistMoveSpeed - this.MinDistMoveSpeed;
        }

        private void Update()
        {
            var destination = this.target.transform.position;
            var distance = Vector2.Distance(this.transform.position, destination);
            
            //We want there to be a range between 2 move speeds.
            //Speed up amount is the ratio of the space between thresholds.
            var SpeedUpPercent = Math.Clamp((distance - this.NearSpeedUpDistance) / this.SpeedUpDifferenceDist, 0, 1);
            //The new max speed is that ratio, times the difference in move speeds, plus the minimum.
            var newSpeedCeiling = (SpeedUpPercent * this.SpeedUpDifferenceSpeed) + this.MinDistMoveSpeed;

            this.directionalMover.SpeedCeiling = newSpeedCeiling;

            if (this.cooldownTimer <= 0f)
            {
                if (distance <= this.attackDistance)
                {
                    this.attackBehaviour.Attack();
                    this.cooldownTimer = this.cooldownDuration;
                }
                this.mover.MoveTo(destination);
            }
            else
            {
                this.mover.Halt();
                this.cooldownTimer -= Time.deltaTime;
            }
            
        }
        
    }
}
