using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Decals
{
    public class PaintTester : MonoBehaviour
    {
        public Camera mainCamera;
        private Vector2 mousePos;
        public event Action<Vector3> SpawnSprite;

        private void Update()
        {
            this.mousePos = UnityEngine.Input.mousePosition;
            if (UnityEngine.Input.GetButtonDown("Fire1"))
            {
                this.SpawnSprite?.Invoke(this.mainCamera.ScreenToWorldPoint(this.mousePos));
                Debug.Log("test fired");
            }
        }


       
    }
}
