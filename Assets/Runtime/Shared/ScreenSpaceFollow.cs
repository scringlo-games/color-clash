using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ScreenSpaceFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform objectToFollow; 
        private Camera mainCamera;
        private RectTransform thisObj;
        [SerializeField]
        private float offsetX;
        [SerializeField]
        private float offsetY;
        [SerializeField]
       

        private void Start()
        {
            //assigns the RectTransform component on 'this' to the 'thisObj' variable
            this.thisObj = this.GetComponent<RectTransform>();
            this.mainCamera = Camera.main;

        }
        private void FixedUpdate()
        {
            //finds the screen pos of 'Object To Follow', then sets the position of 'this' to that screen position
            Vector2 screenPos = this.mainCamera.WorldToScreenPoint(this.objectToFollow.position);
            screenPos.y += this.offsetY;
            screenPos.x += this.offsetX;
            this.thisObj.position = screenPos;
            
        
        }
    }
}
