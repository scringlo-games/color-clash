using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime.UI.UnitStatusFrame.Conditions
{
    public class UnitStatusFrameConditionElementDrawer : MonoBehaviour
    {
        [SerializeField]
        private Image indicatorImage;
        
        public int StackCount { get; set; }

        private void Update()
        {
            if (this.indicatorImage == null)
            {
                return;
            }

            this.indicatorImage.fillAmount = StackCount/8f;
        }
    }
}
