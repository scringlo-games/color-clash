using ScringloGames.ColorClash.Runtime.Shared.ScriptableVariables;
using TMPro;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI
{
    [ExecuteAlways]
    public class SetTextComponentTextToFloatVariableValue : MonoBehaviour
    {
        [TextArea]
        [SerializeField]
        private string formatString = "{0}";
        [Header("Dependencies")]
        [SerializeField]
        private TextMeshProUGUI textMeshComponent;
        [SerializeField]
        private FloatVariable floatVariable;

        private void Update()
        {
            if (this.textMeshComponent.text == null)
            {
                return;
            }

            if (this.floatVariable == null)
            {
                return;
            }

            this.textMeshComponent.text = string.Format(this.formatString, this.floatVariable.Value);
        }
    }
}
