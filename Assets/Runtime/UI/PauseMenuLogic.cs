using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime.UI
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
            this.resumeButton.onClick.AddListener(this.Resume);
            this.quitToMenuButton.onClick.AddListener(this.QuitToMenu);
        }
        void OnDisable()
        {
            this.resumeButton.onClick.RemoveAllListeners();
            this.quitToMenuButton.onClick.RemoveAllListeners();
        }
        void Resume()
        {
            this.pauseHandler.PauseToggle();
            
        }
        void QuitToMenu()
        {
            SceneManager.LoadScene(this.mainMenuScene);
        }
    }
}
