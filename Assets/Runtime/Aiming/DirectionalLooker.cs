using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Aiming
{
    public class DirectionalLooker : MonoBehaviour
    {
        [SerializeField]
        private Transform targetTransform;

        public Vector2 Direction { get; set; }

        private bool isLocked = false;

        private void Reset()
        {
            this.targetTransform = this.transform;
        }

        public void LockRotation()
        {
            isLocked = true;
        }

        public void UnlockRotation()
        {
            isLocked = false;
        }

        private void Update()
        {
            if (!isLocked)
                this.targetTransform.rotation = Quaternion.LookRotation(Vector3.forward, this.Direction);
        }
    }
}
