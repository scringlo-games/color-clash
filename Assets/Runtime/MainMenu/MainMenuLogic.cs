using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
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
        [FormerlySerializedAs("credittReturnButton")]
        [SerializeField]
        private Button creditReturnButton;
        [SerializeField]
        private GameObject creditPanel;
        [SerializeField]
        private string firstSceneName;

        private void OnEnable()
        {
            
            this.startButton.onClick.AddListener(this.LoadFirstScene);
            this.creditButton.onClick.AddListener(this.ToggleCreditPanel);
            this.creditReturnButton.onClick.AddListener(this.ToggleCreditPanel);
            this.quitButton.onClick.AddListener(this.AppQuit);
            this.creditPanel.SetActive(false);
            
            this.startButton.Select();
        }

        private void OnDisable()
        {
            this.startButton.onClick.RemoveAllListeners();
            this.creditButton.onClick.RemoveAllListeners();
            this.creditReturnButton.onClick.RemoveAllListeners();
            this.quitButton.onClick.RemoveAllListeners();
        }

        private void LoadFirstScene()
        {   
            SceneManager.LoadScene(this.firstSceneName);
            Time.timeScale = 1f;
        }

        private void ToggleCreditPanel()
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

        private void AppQuit()
        {
            Application.Quit(); 
        }
    }
}
