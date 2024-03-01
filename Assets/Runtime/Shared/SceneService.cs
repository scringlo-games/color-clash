using ScringloGames.ColorClash.Runtime.GameServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    [CreateAssetMenu(menuName = "Scriptables/Game Services/Scene Service")]
    public class SceneService : GameService
    {
        [SerializeField]
        private SceneAsset titleScene;
        
        public Scene CurrentScene => SceneManager.GetActiveScene();

        public void LoadScene(SceneAsset sceneAsset)
        {
            this.LoadScene(sceneAsset.name);
        }

        public void LoadScene(Scene scene)
        {
            this.LoadScene(scene.name);
        }
        
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void ReloadCurrentScene()
        {
            this.LoadScene(this.CurrentScene);
        }

        public void ReturnToTitleScene()
        {
            this.LoadScene(this.titleScene);
        }
    }
}
