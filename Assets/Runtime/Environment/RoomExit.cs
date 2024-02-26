using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class RoomExit : MonoBehaviour
    {
        [SerializeField]
        private RoomManager manager;
        [SerializeField]
        private Sprite activeSprite;
        private BoxCollider2D thisCollider;
        void Awake()
        {
            if(TryGetComponent<BoxCollider2D>(out var foundCollider))
            {   
                thisCollider = foundCollider;
                thisCollider.enabled = false;
            }

        }
        public void Activate()
        {
            thisCollider.enabled = true;
            this.GetComponent<SpriteRenderer>().sprite = activeSprite;
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.tag == "Player")
            {
                Debug.Log("Load Next Room");
                manager.NextRoom();
            }
        }
        
    }
}