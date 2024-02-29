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
        [SerializeField]
        private string mainMenuScene;

        private void OnEnable()
        {
            this.resumeButton.onClick.AddListener(this.Resume);
            this.quitToMenuButton.onClick.AddListener(this.QuitToMenu);
        }

        private void OnDisable()
        {
            this.resumeButton.onClick.RemoveAllListeners();
            this.quitToMenuButton.onClick.RemoveAllListeners();
        }

        private void Resume()
        {
            this.pauseHandler.PauseToggle();
            
        }

        private void QuitToMenu()
        {
            SceneManager.LoadScene(this.mainMenuScene);
        }
    }
}
