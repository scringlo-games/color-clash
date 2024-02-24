using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class RoomExit : MonoBehaviour
    {
        [SerializeField]
        private RoomManager manager;
        private BoxCollider2D collider;
        void Awake()
        {
            if(TryGetComponent<BoxCollider2D>(out var foundCollider))
            {   
                collider = foundCollider;
                collider.enabled = false;
            }

        }
        void Activate()
        {
            collider.enabled = true;
        }
        
    }
}
