using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public class AttackBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;

        private void OnEnable()
        {
            this.weapon.Trigger.Pull();
        }

        private void OnDisable()
        {
            this.weapon.Trigger.Release();
        }
    }
}
