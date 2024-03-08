using System;
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
            this.playerInput.camera = this.mainCameraVariable.Value;
        }
    }
}