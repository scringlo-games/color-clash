using ScringloGames.ColorClash.Runtime.Shared.ScriptableVariables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class OnAwakeAssignMainCameraToPlayerInput : MonoBehaviour
    {
        [SerializeField]
        private ScriptableVariable<Camera> mainCameraVariable;
        [SerializeField]
        private PlayerInput playerInput;

        private void Awake()
        {
            this.AssignMainCameraToPlayerInput();
        }

        private void OnEnable()
        {
            this.AssignMainCameraToPlayerInput();
        }

        private void AssignMainCameraToPlayerInput()
        {
            if (this.playerInput.camera == null)
            {
                this.playerInput.camera = this.mainCameraVariable.Value;
            }
        }
    }
}
