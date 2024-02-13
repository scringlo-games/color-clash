using UnityEngine;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime.UI
{
    [ExecuteAlways]
    public class ProgressDrawer : MonoBehaviour
    {
        [SerializeField]
        private Image progressImage;
        [Range(0f, 1f)]
        [SerializeField]
        private float progress = 0.5f;
        
        public float Progress
        {
            get => this.progress;
            set => this.progress = Mathf.Clamp01(value);
        }

        private void Update()
        {
            this.UpdateProgress();
        }

        private void OnValidate()
        {
            this.UpdateProgress();
        }
        
        private void UpdateProgress()
        {
            if (this.progressImage == null)
            {
                return;
            }

            this.progressImage.fillAmount = this.Progress;
        }
    }
}
