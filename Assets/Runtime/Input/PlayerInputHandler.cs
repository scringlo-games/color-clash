using System;
using ScringloGames.ColorClash.Runtime.Aiming;
using ScringloGames.ColorClash.Runtime.Mixing;
using ScringloGames.ColorClash.Runtime.Movement;
using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScringloGames.ColorClash.Runtime.Input
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
        [Header("Services")]
        [SerializeField]
        private InputService inputService;
        [SerializeField]
        private MixingService mixingService;

        private void OnEnable()
        {
            this.inputService.MoveStarted += this.OnMoveStarted;
            this.inputService.MoveStopped += this.OnMoveStopped;
            this.inputService.WeaponSlotEquipped += this.OnWeaponSlotEquipped;
        }
        
        private void OnDisable()
        {
            this.inputService.MoveStarted -= this.OnMoveStarted;
            this.inputService.MoveStopped -= this.OnMoveStopped;
            this.inputService.WeaponSlotEquipped -= this.OnWeaponSlotEquipped;
        }

        private void Update()
        {
            if (this.inputService.IsAttacking)
            {
                this.paintProjectileWeapon.Trigger.Pull();
            }
            else
            {
                this.paintProjectileWeapon.Trigger.Release();
            }

            var lookVector = this.inputService.LookVector;

            if (lookVector.magnitude > 0f)
            {
                switch (this.playerInput.currentControlScheme)
                {
                    case "KeyboardAndMouse":
                        var cam = this.playerInput.camera;
                        var from = (Vector2) cam.WorldToScreenPoint(this.looker.transform.position);
                        this.looker.Direction = (lookVector - from).normalized;
                        break;
                    case "Gamepad":
                        this.looker.Direction = lookVector.normalized;
                    
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnMoveStarted(Vector2 direction)
        {
            this.mover.Direction = direction;
            this.mover.StartAccelerating();
        }

        private void OnMoveStopped(Vector2 direction)
        {
            this.mover.IsAccelerating = false;
            this.mover.StopAccelerating();
        }

        private void OnWeaponSlotEquipped(int index)
        {
            var color = index switch
            {
                1 => this.mixingService.Table.Red,
                2 => this.mixingService.Table.Blue,
                3 => this.mixingService.Table.Yellow,
                _ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
            };
            
            this.mixingService.Mixer.AddColor(color);
        }
    }
}
