﻿using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters
{
    [CreateAssetMenu(menuName = "Scriptables/Collision Filters/IsEnemy")]
    public class IsEnemy : GameObjectFilter
    {
        public override bool Evaluate(GameObject gameObject)
        {
            return gameObject.CompareTag("Enemy");
        }
    }
}
