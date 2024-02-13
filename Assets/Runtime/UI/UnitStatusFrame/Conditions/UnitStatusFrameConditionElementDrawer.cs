using TMPro;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.UnitStatusFrame.Conditions
{
    public class UnitStatusFrameConditionElementDrawer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textComponent;
        
        public int StackCount { get; set; }

        private void Update()
        {
            if (this.textComponent == null)
            {
                return;
            }

            this.textComponent.text = this.StackCount.ToString();
        }
    }
}
