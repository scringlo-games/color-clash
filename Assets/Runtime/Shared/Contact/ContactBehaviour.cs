using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared.Contact
{
    [RequireComponent(typeof(ContactHandler))]
    public abstract class ContactBehaviour : MonoBehaviour
    {
        public virtual void OnCollisionEntered(Collision2D collision2D)
        {
        }
        
        public virtual void OnCollisionStayed(Collision2D collision2D)
        {
        }
        
        public virtual void OnCollisionExited(Collision2D collision2D)
        {
        }
        
        public virtual void OnTriggerEntered(Collider2D collider2D)
        {
        }
        
        public virtual void OnTriggerStayed(Collider2D collider2D)
        {
        }
        
        public virtual void OnTriggerExited(Collider2D collider2D)
        {
        }
    }
}
