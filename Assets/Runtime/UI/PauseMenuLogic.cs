using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime
{
    public class PauseMenuLogic : MonoBehaviour
    {
        [SerializeField]
        private PauseHandler pauseHandler;
        [SerializeField]
        private Button resumeButton;
        [SerializeField]
        private Button quitToMenuButton;
        [SerializeField] string mainMenuScene;
        void OnEnable()
        {
            resumeButton.onClick.AddListener(Resume);
            quitToMenuButton.onClick.AddListener(QuitToMenu);
        }
        void OnDisable()
        {
            resumeButton.onClick.RemoveAllListeners();
            quitToMenuButton.onClick.RemoveAllListeners();
        }
        void Resume()
        {
            pauseHandler.PauseToggle();
            
        }
        void QuitToMenu()
        {
            SceneManager.LoadScene(mainMenuScene);
        }
    }
}
