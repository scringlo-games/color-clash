using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.UnitStatusFrame
{
    public class UnitStatusFrameDrawer : MonoBehaviour, IBindable
    {
        private AttachToWorldSpaceObject attachBehaviour;
        
        public GameObject BoundTo { get; private set; }

        public void Bind(GameObject gameObject)
        {
            this.BoundTo = gameObject;

            if (this.TryGetComponent(out AttachToWorldSpaceObject attach))
            {
                this.attachBehaviour = attach;
            }

            if (this.attachBehaviour != null)
            {
                this.attachBehaviour.ObjectToFollow = this.BoundTo.transform;
            }
        }

        public void Unbind()
        {
            if (this.attachBehaviour != null)
            {
                this.attachBehaviour.ObjectToFollow = null;
            }
        }
    }
}
