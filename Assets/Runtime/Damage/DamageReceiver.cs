using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.Damage
{
    public class DamageReceiver : MonoBehaviour
    {
        [SerializeField]
        private DamageArgsEvent damagedEvent;
        
        public void TakeDamage([NotNull] DamageSource source, float amount)
        {
            var args = new DamageArgs()
            {
                Originator = source.Originator,
                Source = source,
                Receiver = this,
                Amount = amount,
            };
            
            this.damagedEvent.Raise(args);
        }
    }
}
