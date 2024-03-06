using System;
using ScringloGames.ColorClash.Runtime.GameServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ScringloGames.ColorClash.Runtime.Input
{
    [CreateAssetMenu(menuName = "Scriptables/Game Services/Input Service")]
    public class InputService : GameService, GameInput.IGameplayActions
    {
        [Header("Events")]
        [SerializeField]
        private UnityEvent<Vector2> moveStarted;
        [SerializeField]
        private UnityEvent<Vector2> moveStopped;
        [SerializeField]
        private UnityEvent attackStarted;
        [SerializeField]
        private UnityEvent attackStopped;
        [SerializeField]
        private UnityEvent<int> weaponSlotEquipped;
        [SerializeField]
        private UnityEvent paused;
        private GameInput gameInput;
        
        public Vector2 LookVector { get; private set; }
        public bool IsAttacking { get; private set; }
        
        public event Action<Vector2> MoveStarted;
        public event Action<Vector2> MoveStopped;
        public event Action AttackStarted;
        public event Action AttackStopped;
        public event Action<int> WeaponSlotEquipped;
        public event Action Paused;

        public override void Setup()
        {
            this.gameInput = new GameInput();
            this.gameInput.Gameplay.SetCallbacks(this);

            this.EnableGameplayInput();
        }

        public override void Tick(float deltaTime)
        {
        }

        public override void Teardown()
        {
            this.gameInput.Gameplay.RemoveCallbacks(this);
        }

        public void EnableAllInput()
        {
            this.gameInput.Enable();
            
            this.EnableGameplayInput();
        }

        public void DisableAllInput()
        {
            this.DisableGameplayInput();
            
            this.gameInput.Disable();
        }

        public void EnableGameplayInput()
        {
            this.gameInput.Gameplay.Enable();
        }

        public void DisableGameplayInput()
        {
            this.gameInput.Gameplay.Disable();
        }

        void GameInput.IGameplayActions.OnMove(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();

            if (context.phase == InputActionPhase.Performed)
            {
                this.moveStarted?.Invoke(direction);
                this.MoveStarted?.Invoke(direction);
            }
            if (context.phase == InputActionPhase.Canceled)
            {
                this.moveStopped?.Invoke(direction);
                this.MoveStopped?.Invoke(direction);
            }
        }

        void GameInput.IGameplayActions.OnLook(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                this.LookVector = this.gameInput.Gameplay.Look.ReadValue<Vector2>();
            }
        }

        void GameInput.IGameplayActions.OnFire(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                this.IsAttacking = true;
                this.attackStarted?.Invoke();
                this.AttackStarted?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                this.IsAttacking = false;
                this.attackStopped?.Invoke();
                this.AttackStopped?.Invoke();
            }
        }

        void GameInput.IGameplayActions.OnEquipWeaponSlot1(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                this.weaponSlotEquipped?.Invoke(1);
                this.WeaponSlotEquipped?.Invoke(1);
            }
        }

        void GameInput.IGameplayActions.OnEquipWeaponSlot2(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                this.weaponSlotEquipped?.Invoke(2);
                this.WeaponSlotEquipped?.Invoke(2);
            }
        }

        void GameInput.IGameplayActions.OnEquipWeaponSlot3(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                this.weaponSlotEquipped?.Invoke(3);
                this.WeaponSlotEquipped?.Invoke(3);
            }
        }

        void GameInput.IGameplayActions.OnPause(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                this.paused?.Invoke();
                this.Paused?.Invoke();
            }
        }
    }
}
