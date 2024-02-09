using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class Destructible : MonoBehaviour
    {
        /// <summary>
        /// Invoked when the object is about to be destroyed.
        /// </summary>
        public event Action<Destructible> Destroying;

        /// <summary>
        /// Destroys the entity.
        /// </summary>
        public void Destroy()
        {
            this.Destroying?.Invoke(this);
            Object.Destroy(this.gameObject);
        }
    }
}
