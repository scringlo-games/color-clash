using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Conditions
{
    public class ApplySlowCondition : MonoBehaviour
    {
        public void ApplyTo(GameObject gameObject, float slowPercent, float duration)
        {
            if (gameObject.TryGetComponent<ConditionBank>(out var bank))
            {
                var condition = new SlowCondition(slowPercent)
                {
                    Duration = duration,
                };
                bank.Apply(condition);
            }
        } 
    }
}
