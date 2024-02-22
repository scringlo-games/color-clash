using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime
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
            startButton.onClick.AddListener(LoadFirstScene);
            creditButton.onClick.AddListener(ToggleCreditPanel);
            credittReturnButton.onClick.AddListener(ToggleCreditPanel);
            quitButton.onClick.AddListener(AppQuit);
            creditPanel.SetActive(false);
        }
        void OnDisable()
        {
            startButton.onClick.RemoveAllListeners();
            creditButton.onClick.RemoveAllListeners();
            credittReturnButton.onClick.RemoveAllListeners();
            quitButton.onClick.RemoveAllListeners();
        }
        void LoadFirstScene()
        {   
            SceneManager.LoadScene(firstSceneName);
            Time.timeScale = 1f;
        }
        void ToggleCreditPanel()
        {
            if(creditPanel.activeSelf)
            {
                creditPanel.SetActive(false);
            }
            else if (!creditPanel.activeSelf)
            {
                creditPanel.SetActive(true);
            }
            
        }
        void AppQuit()
        {
            Application.Quit(); 
        }
    }
}
