using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class SetObjectParent : MonoBehaviour
    {
        [SerializeField]
        private GameObject target;
        [SerializeField]
        private string targetNewParent;
        void OnEnable()
        {
            this.target.transform.parent = GameObject.Find(targetNewParent).transform;
        }
    }
}
