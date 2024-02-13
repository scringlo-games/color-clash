using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.UnitStatusFrame
{
    public class UnitStatusFrameDrawer : MonoBehaviour, IBindable<GameObject>
    {
        [SerializeField]
        private AttachToWorldSpaceObject attachBehaviour;
        
        public GameObject BoundTo { get; private set; }
        
        public void Bind(GameObject gameObject)
        {
            this.BoundTo = gameObject;
            this.attachBehaviour.ObjectToFollow = this.BoundTo.transform;
        }

        public void Unbind()
        {
            this.attachBehaviour.ObjectToFollow = null;
        }
    }
}
