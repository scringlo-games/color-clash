using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared.Attributes
{
    public class AttributeBank : MonoBehaviour
    {
        [Header("Power")]
        [Tooltip("How much damage do I deal to ALL entities?")]
        [SerializeField]
        private Attribute globalDamageDealtMultiplier;
        [Header("Toughness")]
        [Tooltip("How much damage do I take from ALL entities?")]
        [SerializeField]
        private Attribute globalDamageTakenMultiplier;
        [Header("Mobility")]
        [Tooltip("How fast do I move?")]
        [SerializeField]
        private Attribute movementSpeedMultiplier;

        public Attribute MovementSpeedMultiplier => this.movementSpeedMultiplier;

        private void OnValidate()
        {
            this.ForceRecalculateAllAttributes();
        }

        private void ForceRecalculateAllAttributes()
        {
            this.globalDamageDealtMultiplier.ForceRecalculateModifiedValue();
            this.globalDamageTakenMultiplier.ForceRecalculateModifiedValue();
            this.movementSpeedMultiplier.ForceRecalculateModifiedValue();
        }
    }
}
