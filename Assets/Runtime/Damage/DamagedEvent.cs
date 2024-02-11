using TravisRFrench.Common.Runtime.ScriptableEvents;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Damage
{
    [CreateAssetMenu(menuName = "Scriptables/Events/Entity Damaged")]
    public class DamagedEvent : ScriptableEvent<DamageArgs>
    {
    }
}
