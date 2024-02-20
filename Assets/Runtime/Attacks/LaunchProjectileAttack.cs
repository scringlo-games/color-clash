using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Attacks
{
    public class LaunchProjectileAttack : AttackBehaviour
    {
        [SerializeField]
        private ProjectileLauncher launcher;
        
        protected override void OnAttack()
        {
            this.launcher.Launch();
        }
    }
}
