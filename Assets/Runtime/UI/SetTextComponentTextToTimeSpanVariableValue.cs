using System;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI
{
    [ExecuteAlways]
    public class SetTextComponentTextToTimeSpanVariableValue : SetTextComponentTextToScriptableVariableValue<TimeSpan>
    {
        protected override string GetFormatted(TimeSpan value, string formatString)
        {
            return string.Format(formatString, value.Minutes, value.Seconds);
        }
    }
}
