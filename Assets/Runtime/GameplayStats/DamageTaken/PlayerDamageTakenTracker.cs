using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Shared.ScriptableVariables;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.GameplayStats.DamageTaken
{
    public class PlayerDamageTakenTracker : MonoBehaviour
    {
        [SerializeField]
        private ScriptableVariable<float> playerDamageTakenVariable;
        
        [SerializeField]
        private DamageArgsEvent damageTakenEvent;

        private void OnEnable()
        {
            this.damageTakenEvent.Raised += this.OnDamageTaken;
        }

        private void OnDamageTaken(DamageArgs args)
        {
            if (!args.Receiver.gameObject.CompareTag("Player"))
            {
                return;
            }

            this.playerDamageTakenVariable.Value += args.Amount;
        }
    }
}
