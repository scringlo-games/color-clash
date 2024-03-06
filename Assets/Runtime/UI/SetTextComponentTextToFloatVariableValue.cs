using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI
{
    [ExecuteAlways]
    public class SetTextComponentTextToFloatVariableValue : SetTextComponentTextToScriptableVariableValue<float>
    {
        protected override string GetFormatted(float value, string formatString)
        {
            return string.Format(formatString, value);
        }
    }
}
