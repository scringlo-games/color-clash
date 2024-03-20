using ScringloGames.ColorClash.Runtime.Shared.ScriptableVariables;
using TMPro;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI
{
    [ExecuteAlways]
    public abstract class SetTextComponentTextToScriptableVariableValue<TValue> : MonoBehaviour
    {
        [TextArea]
        [SerializeField]
        private string formatString = "{0}";
        [Header("Dependencies")]
        [SerializeField]
        private TextMeshProUGUI textMeshComponent;
        [SerializeField]
        private ScriptableVariable<TValue> scriptableVariable;

        private void Update()
        {
            if (this.textMeshComponent.text == null)
            {
                return;
            }

            if (this.scriptableVariable == null)
            {
                return;
            }

            this.textMeshComponent.text = this.GetFormatted(this.scriptableVariable.Value, this.formatString);
        }

        protected abstract string GetFormatted(TValue value, string formatString);
    }
}
