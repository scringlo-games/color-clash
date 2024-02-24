using System;
using ScringloGames.ColorClash.Runtime.Movement;
using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public class FoamFistAIBrain : MonoBehaviour
    {
        [SerializeField]
        private GameObject target;
        [SerializeField]
        private DestinationMover mover;
        [SerializeField]
        private Weapon weapon;
        [SerializeField] 
        private float maxDistMoveSpeed;
        [SerializeField] 
        private float minDistMoveSpeed;

        /// <summary>
        /// Beyond this distance, min move speed.
        /// </summary>
        [SerializeField] private float farSpeedUpDistance;

        /// <summary>
        /// At this distance or closer, max move speed.
        /// </summary>
        [SerializeField] private float nearSpeedUpDistance;
        //Difference between Far and Near distance, or the range.
        private float speedUpDifferenceDist;
        //Difference between Far and Near speeds.
        private float speedUpDifferenceSpeed;
        
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
            this.speedUpDifferenceDist = this.farSpeedUpDistance - this.nearSpeedUpDistance;
            this.speedUpDifferenceSpeed = this.maxDistMoveSpeed - this.minDistMoveSpeed;
        }

        private void Update()
        {
            var destination = this.target.transform.position;
            var distance = Vector2.Distance(this.transform.position, destination);
            
            //We want there to be a range between 2 move speeds.
            //Speed up amount is the ratio of the space between thresholds.
            var speedUpPercent = Math.Clamp((distance - this.nearSpeedUpDistance) / this.speedUpDifferenceDist, 0, 1);
            //The new max speed is that ratio, times the difference in move speeds, plus the minimum.
            var newSpeedCeiling = (speedUpPercent * this.speedUpDifferenceSpeed) + this.minDistMoveSpeed;

            this.directionalMover.SpeedCeiling = newSpeedCeiling;

            if (this.cooldownTimer <= 0f)
            {
                if (distance <= this.attackDistance)
                {
                    this.weapon.Trigger.Pull();
                    this.cooldownTimer = this.cooldownDuration;
                }
                else
                {
                    this.weapon.Trigger.Release();
                    this.mover.MoveTo(destination);
                }
            }
            else
            {
                this.mover.Halt();
                this.cooldownTimer -= Time.deltaTime;
            }
            
        }
        
    }
}
