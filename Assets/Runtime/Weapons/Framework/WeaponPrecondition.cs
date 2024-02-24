using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Weapons.Framework
{
    public abstract class WeaponPrecondition : MonoBehaviour, IWeaponPrecondition
    {
        public abstract bool Evaluate();
    }
}
