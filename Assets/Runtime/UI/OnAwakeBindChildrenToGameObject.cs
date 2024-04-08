using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI
{
    public class OnAwakeBindChildrenToGameObject : MonoBehaviour
    {
        [SerializeField]
        private GameObject bindTo;
        
        private void Awake()
        {
            if (this.bindTo == null)
            {
                return;
            }

            var bindables = this.GetComponentsInChildren<IBindable>(true);

            foreach (var bindable in bindables)
            {
                bindable.Bind(bindTo);
            }
        }
    }
}