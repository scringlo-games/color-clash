using ScringloGames.ColorClash.Runtime.Conditions;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ApplyAOEConditionToOtherOnCollisionEnter : ApplyConditionToOtherOnCollisionEnter
    {
        protected override Condition GetCondition()
        {
            return new AOECondition()
            {
                Duration = 2f,
            };
        }
    }
}
