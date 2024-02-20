using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Aiming
{
    public class DirectionalLooker : MonoBehaviour
    {
        [SerializeField]
        private Transform targetTransform;

        public Vector2 Direction { get; set; }

        private void Reset()
        {
            this.targetTransform = this.transform;
        }

        private void Update()
        {
            this.targetTransform.rotation = Quaternion.LookRotation(Vector3.forward, this.Direction);
        }
    }
}
