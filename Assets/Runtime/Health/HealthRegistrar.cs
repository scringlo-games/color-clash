using TravisRFrench.Common.Runtime.Registration;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Health
{
    [CreateAssetMenu(menuName = "Scriptables/Registrars/Health Registrar")]
    public class HealthRegistrar : ScriptableRegistrar<HealthHandler>
    {
    }
}
