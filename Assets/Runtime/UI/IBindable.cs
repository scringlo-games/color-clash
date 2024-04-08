using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI
{
    public interface IBindable
    {
        GameObject BoundTo { get; }
        
        void Bind(GameObject obj);
        void Unbind();
    }
}
