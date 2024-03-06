using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class GameObjectRegistree : MonoBehaviour
    {
        [SerializeField]
        private GameObjectRegistrar registrar;

        private void OnEnable()
        {
            this.registrar.Register(this.gameObject);
        }

        private void OnDisable()
        {
            this.registrar.Deregister(this.gameObject);
        }
    }
}
