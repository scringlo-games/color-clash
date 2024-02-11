using System;
using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime.UI.Health
{
    /// <summary>
    /// Updates the fillAmount of the specified <see cref="healthImageComponent"/> to reflect changes to the health of
    /// the specified <see cref="healthHandler"/>.
    /// </summary>
    public class HealthDrawer : MonoBehaviour
    {
        [SerializeField]
        private HealthHandler healthHandler;
        [SerializeField]
        private Image healthImageComponent;
        
        /// <summary>
        /// The currently bound entity.
        /// </summary>
        public HealthHandler HealthHandler => this.healthHandler;

        /// <summary>
        /// Binds to the specified entity, causing changes in its health to update the UI.
        /// </summary>
        /// <param name="handler">The entity this should be bound to.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void BindTo(HealthHandler handler)
        {
            // We had to convert from a simple OnEnable subscription to this binding pattern. The reason is that
            // if the object gets instantiated at runtime, we didn't have a way to assign HealthHandler before
            // the OnEnable callback was invoked. By removing the call from OnEnable and exposing a method for binding,
            // we can allow the calling code to take care of binding as soon as it is able to.
            
            if (handler == null)
            {
                throw new ArgumentNullException();
            }
            
            if (handler != this.HealthHandler)
            {
                this.Unbind();
            }
            
            this.healthHandler = handler;
            this.HealthHandler.HealthChanged += this.OnHealthChanged;
        }

        /// <summary>
        /// Unbinds from the currently bound entity, causing changes in its health to no longer update the UI.
        /// </summary>
        public void Unbind()
        {
            if (this.HealthHandler == null)
            {
                return;
            }
            
            this.HealthHandler.HealthChanged -= this.OnHealthChanged;
        }

        private void OnEnable()
        {
            // We want instances that only do their binding through the inspector and not via code to still work

            if (this.HealthHandler != null)
            {
                this.BindTo(this.HealthHandler);
            }
        }

        private void OnDisable()
        {
            this.Unbind();
        }

        private void OnHealthChanged(int amount)
        {
            // If something happened to the bound entity we can't update the bar without a reference to MaxHealth
            // and unfortunately have to ignore the health change. This might be solved by passing a reference to the
            // handler rather than just the amount changed in the event delegate.
            if (this.HealthHandler == null)
            {
                return;
            }
            
            //divides the current health by max health to return a float value between 0 - 1. This value is then used to 
            //set the fill amount of the indicator image.
            
            var fill = (float)amount/(float)this.HealthHandler.MaxHealth;
            this.healthImageComponent.fillAmount = fill;
        }
    }
}
