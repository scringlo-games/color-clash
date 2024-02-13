using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class OnCollisionEnterDestroySelf : OnCollisionEnterDestroy
    {
        protected override GameObject GetDestroyTarget(Collision2D collision)
        {
            return this.gameObject;
        }
    }
}
