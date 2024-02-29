using TMPro;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.Windows
{
    [ExecuteAlways]
    public class Window : MonoBehaviour
    {
        [SerializeField]
        private string title = "Window";
        [Header("Dependencies")]
        [SerializeField]
        private GameObject mainContainer;
        [SerializeField]
        private TextMeshProUGUI titleTextComponent;

        public string Title
        {
            get => this.title;
            set => this.title = value;
        }
        
        private void Update()
        {
            if (this.titleTextComponent == null)
            {
                return;
            }
            
            this.titleTextComponent.text = this.title;
        }

        public void Show()
        {
            this.mainContainer.SetActive(true);
        }

        public void Hide()
        {
            this.mainContainer.SetActive(false);
        }
    }
}
