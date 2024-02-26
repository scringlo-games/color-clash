using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime.MainMenu
{
    public class MainMenuLogic : MonoBehaviour
    {
        [SerializeField]
        private Button quitButton;
        [SerializeField]
        private Button startButton;
        [SerializeField]
        private Button creditButton;
        [SerializeField]
        private Button credittReturnButton;
        [SerializeField]
        private GameObject creditPanel;
        [SerializeField]
        private string firstSceneName;
        void OnEnable()
        {
            this.startButton.onClick.AddListener(this.LoadFirstScene);
            this.creditButton.onClick.AddListener(this.ToggleCreditPanel);
            this.credittReturnButton.onClick.AddListener(this.ToggleCreditPanel);
            this.quitButton.onClick.AddListener(this.AppQuit);
            this.creditPanel.SetActive(false);
        }
        void OnDisable()
        {
            this.startButton.onClick.RemoveAllListeners();
            this.creditButton.onClick.RemoveAllListeners();
            this.credittReturnButton.onClick.RemoveAllListeners();
            this.quitButton.onClick.RemoveAllListeners();
        }
        void LoadFirstScene()
        {   
            SceneManager.LoadScene(this.firstSceneName);
            Time.timeScale = 1f;
        }
        void ToggleCreditPanel()
        {
            if(this.creditPanel.activeSelf)
            {
                this.creditPanel.SetActive(false);
            }
            else if (!this.creditPanel.activeSelf)
            {
                this.creditPanel.SetActive(true);
            }
            
        }
        void AppQuit()
        {
            Application.Quit(); 
        }
    }
}
