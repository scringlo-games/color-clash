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

        private void Awake()
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

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.CompareTag("Player"))
            {
                this.manager.NextRoom();
            }
        }
    }
}
