using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.Shared.Contact
{
    public class ContactHandler : MonoBehaviour
    {
        [SerializeField]
        private List<ContactBehaviour> behaviours;
        
        private void Reset()
        {
            this.GetBehaviours();
        }

        private void GetBehaviours()
        {
            foreach (var behaviour in this.GetComponents<ContactBehaviour>())
            {
                if (this.behaviours.Contains(behaviour))
                {
                    continue;
                }
                
                this.behaviours.Add(behaviour);
            }
        }
        
        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            foreach (var behaviour in this.behaviours)
            {
                behaviour.OnCollisionEntered(collision2D);
            }
        }
        
        private void OnCollisionStay2D(Collision2D collision2D)
        {
            foreach (var behaviour in this.behaviours)
            {
                behaviour.OnCollisionStayed(collision2D);
            }
        }

        private void OnCollisionExit2D(Collision2D collision2D)
        {
            foreach (var behaviour in this.behaviours)
            {
                behaviour.OnCollisionExited(collision2D);
            }
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            foreach (var behaviour in this.behaviours)
            {
                behaviour.OnTriggerEntered(collider2D);
            }
        }

        private void OnTriggerStay2D(Collider2D collider2D)
        {
            foreach (var behaviour in this.behaviours)
            {
                behaviour.OnTriggerStayed(collider2D);
            }
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            foreach (var behaviour in this.behaviours)
            {
                behaviour.OnTriggerExited(collider2D);
            }
        }
    }
}
