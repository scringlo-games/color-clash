using System.Collections.Generic;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class DestroyOtherOnDisable : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> others;

        private void OnDisable()
        {
            foreach(var target in this.others)
            {
                Destroy(target);
            }
        }
    }
}
