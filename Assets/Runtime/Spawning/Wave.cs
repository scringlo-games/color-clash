using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Spawning
{
    [Serializable]
    public class Wave
    {
        [SerializeField]
        private List<GameObject> prefabs;

        public IEnumerable<GameObject> Prefabs => this.prefabs;
    }
}
