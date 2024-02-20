using System;
using ScringloGames.ColorClash.Runtime.Attacks;
using ScringloGames.ColorClash.Runtime.Movement;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

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
        [SerializeField] 
        private float MaxMoveSpeed;
        [SerializeField] 
        private float MinMoveSpeed;

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

        private void OnEnable()
        {
            this.target = GameObject.FindWithTag("Player");
            
            //Math that creates variables for easy use
            SpeedUpDifferenceDist = FarSpeedUpDistance - NearSpeedUpDistance;
            SpeedUpDifferenceSpeed = MaxMoveSpeed - MinMoveSpeed;
        }

        private void Update()
        {
            var destination = this.target.transform.position;
            var distance = Vector2.Distance(this.transform.position, destination);
            
            //We want there to be a range between 2 move speeds.
            //Speed up amount is the ratio of the space between thresholds.
            var SpeedUpPercent = Math.Clamp((distance - NearSpeedUpDistance) / SpeedUpDifferenceDist, 0, 1);
            //The new max speed is that ratio, times the difference in move speeds, plus the minimum.
            var newSpeedCeiling = (SpeedUpPercent * SpeedUpDifferenceSpeed) + MinMoveSpeed;
            
            directionalMover.SpeedCeiling = newSpeedCeiling;
            
            if (distance <= this.attackDistance)
            {
                this.attackBehaviour.Attack();
            }
            else
            {
                this.mover.MoveTo(destination);
            }
        }
    }
}
