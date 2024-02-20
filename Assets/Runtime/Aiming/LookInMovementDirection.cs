using System;
using ScringloGames.ColorClash.Runtime.Movement;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Aiming
{
    public class LookInMovementDirection : MonoBehaviour
    {
        [SerializeField]
        private DirectionalLooker looker;
        [SerializeField]
        private DirectionalMover mover;
        
        private void Update()
        {
            this.looker.Direction = this.mover.Direction;
        }
    }
}
