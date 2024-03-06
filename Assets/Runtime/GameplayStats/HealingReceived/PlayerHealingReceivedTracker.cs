using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Shared.ScriptableVariables;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.GameplayStats.HealingReceived
{
    public class PlayerHealingReceivedTracker : MonoBehaviour
    {
        [SerializeField]
        private ScriptableVariable<float> playerHealingReceivedVariable;
        [SerializeField]
        private DamageArgsEvent healingReceivedEvent;

        private void OnEnable()
        {
            this.healingReceivedEvent.Raised += this.OnHealingReceived;
        }

        private void OnHealingReceived(DamageArgs args)
        {
            if (!args.Receiver.gameObject.CompareTag("Player"))
            {
                return;
            }

            this.playerHealingReceivedVariable.Value += args.Amount;
        }
    }
}
