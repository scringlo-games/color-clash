using ScringloGames.ColorClash.Runtime.Aiming;
using ScringloGames.ColorClash.Runtime.Input;
using ScringloGames.ColorClash.Runtime.Mixing;
using ScringloGames.ColorClash.Runtime.Movement;
using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScringloGames.ColorClash.Runtime.Actors.PlayerCharacter
{
    /// <summary>
    /// Responsible for binding the player's inputs to their respective actions in-game.
    /// </summary>
    public class PlayerInputHandler : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField]
        private PlayerInput playerInput;
        [SerializeField]
        private DirectionalMover mover;
        [SerializeField]
        private DirectionalLooker looker;
        [SerializeField]
        private Weapon paintProjectileWeapon;
        [SerializeField]
        private MixingService mixingService;
        
        private GameInput gameInput;
        
        private void Awake()
        {
            this.gameInput = new GameInput();
        }

        private void OnEnable()
        {
            this.gameInput.Gameplay.Enable();
            
            this.gameInput.Gameplay.Move.performed += this.OnMovePerformed;
            this.gameInput.Gameplay.Move.canceled += this.OnMoveCancelled;
            this.gameInput.Gameplay.Look.performed += this.OnLookPerformed;
            this.gameInput.Gameplay.UseWeapon1.performed += this.OnUseWeapon1Performed;
            this.gameInput.Gameplay.UseWeapon2.performed += this.OnUseWeapon2Performed;
            this.gameInput.Gameplay.UseWeapon3.performed += this.OnUseWeapon3Performed;
        }

        private void OnDisable()
        {
            this.gameInput.Gameplay.Disable();
            
            this.gameInput.Gameplay.Move.performed -= this.OnMovePerformed;
            this.gameInput.Gameplay.Move.canceled -= this.OnMoveCancelled;
            this.gameInput.Gameplay.Look.performed -= this.OnLookPerformed;
            this.gameInput.Gameplay.UseWeapon1.performed -= this.OnUseWeapon1Performed;
            this.gameInput.Gameplay.UseWeapon2.performed -= this.OnUseWeapon2Performed;
            this.gameInput.Gameplay.UseWeapon3.performed -= this.OnUseWeapon3Performed;
        }

        private void Update()
        {
            if (this.gameInput.Gameplay.Fire.phase == InputActionPhase.Performed)
            {
                this.paintProjectileWeapon.Trigger.Pull();
            }
            else
            {
                this.paintProjectileWeapon.Trigger.Release();
            }
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            // Do this when the move input is pressed

            var direction = context.ReadValue<Vector2>();
            
            this.mover.Direction = direction;
            this.mover.StartAccelerating();
        }
        
        private void OnMoveCancelled(InputAction.CallbackContext context)
        {
            // Do this when the move input is released
            
            this.mover.IsAccelerating = false;
            this.mover.StopAccelerating();
        }

        private void OnLookPerformed(InputAction.CallbackContext context)
        {
            // Do this when a "look" input is detected

            var input = context.ReadValue<Vector2>();
            
            switch (this.playerInput.currentControlScheme)
            {
                case "KeyboardAndMouse":
                    var cam = this.playerInput.camera;
                    var from = (Vector2) cam.WorldToScreenPoint(this.looker.transform.position);
                    this.looker.Direction = (input - from).normalized;
                    break;
                case "Gamepad":
                    this.looker.Direction = input.normalized;
                    break;
                default:
                    break;
            }
        }

        private void OnUseWeapon1Performed(InputAction.CallbackContext context)
        {
            this.mixingService.Mixer
                .AddColor(this.mixingService.Table.Red);
        }

        private void OnUseWeapon2Performed(InputAction.CallbackContext context)
        {
            this.mixingService.Mixer
                .AddColor(this.mixingService.Table.Blue);
        }
        
        private void OnUseWeapon3Performed(InputAction.CallbackContext context)
        {
            this.mixingService.Mixer
                .AddColor(this.mixingService.Table.Yellow);
        }
    }
}
