using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Environment
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
            if(this.TryGetComponent<BoxCollider2D>(out var foundCollider))
            {
                this.thisCollider = foundCollider;
                this.thisCollider.enabled = false;
            }

        }
        public void Activate()
        {
            this.thisCollider.enabled = true;
            this.GetComponent<SpriteRenderer>().sprite = this.activeSprite;
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.tag == "Player")
            {
                Debug.Log("Load Next Room");
                this.manager.NextRoom();
            }
        }
        
    }
}
