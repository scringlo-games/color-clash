using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class ResetSceneOnDeath : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField]
        private Killable death;
        [Header("Services")]
        [SerializeField]
        private SceneService sceneService;

        private void OnEnable()
        {
          this.death.Killed += this.ResetScene;
        }

        private void OnDisable()
        {
          this.death.Killed -= this.ResetScene;
        }

        private void ResetScene()
        {
          this.sceneService.ReloadCurrentScene();
        }
    }
}
