using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI
{
    /// <summary>
    /// Attaches to a world space object and maintains the specified offset from it in screen space.
    /// </summary>
    [ExecuteAlways]
    public class AttachToWorldSpaceObject : MonoBehaviour
    {
        [SerializeField]
        private Transform objectToFollow;
        [SerializeField]
        private Vector2 offset;
        private RectTransform thisTransform;
        private Camera mainCamera;

        /// <summary>
        /// The world space object to which this object should attach.
        /// </summary>
        public Transform ObjectToFollow
        {
            get => this.objectToFollow;
            set => this.objectToFollow = value;
        }
        /// <summary>
        /// The offset to retain while attached.
        /// </summary>
        public Vector2 Offset
        {
            get => this.offset;
            set => this.offset = value;
        }

        private void Awake()
        {
            this.thisTransform = this.GetComponent<RectTransform>();
            this.mainCamera = Camera.main;
        }
        private void Update()
        {
            if (this.ObjectToFollow == null || this.mainCamera == null)
            {
                return;
            }
            
            var screenPoint = this.mainCamera.WorldToScreenPoint(this.ObjectToFollow.position);
            this.thisTransform.position = screenPoint + (Vector3)this.Offset;
        }
    }
}
