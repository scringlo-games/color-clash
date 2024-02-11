using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class OnCollisionEnterDestroyOther : OnCollisionEnterDestroy
    {
        protected override GameObject GetDestroyTarget(Collision2D collision)
        {
            return collision.collider.gameObject;
        }
    }
}
