using System;
using System.Collections.Generic;
using System.Linq;
using TravisRFrench.Common.Runtime.Timing;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScringloGames.ColorClash.Runtime.UI.InputPromptHUD
{
    public class InputPromptHUD : MonoBehaviour
    {
        [Serializable]
        private record Entry
        {
            public InputActionReference InputActionReference;
            public InputPromptDrawer Prompt;
        }
        
        [SerializeField]
        private Interval interval;
        [SerializeField]
        private List<Entry> entries;
        private List<InputAction> unusedActions;

        private void Awake()
        {
            this.unusedActions = new List<InputAction>();
            
            this.unusedActions = this.entries
                .Select(entry => entry.InputActionReference.action)
                .ToList();
        }

        private void OnEnable()
        {
            foreach (var action in this.unusedActions)
            {
                this.SubscribeToAction(action);
            }
            
            this.interval.Elapsed += this.OnIntervalElapsed;
            this.interval.Start();
        }

        private void OnDisable()
        {
            foreach (var action in this.unusedActions)
            {
                this.UnsubscribeFromAction(action);
            }
            
            this.interval.Elapsed -= this.OnIntervalElapsed;
        }

        private void Update()
        {
            this.interval.Tick(Time.deltaTime);
        }

        public void SubscribeToAction(InputAction action)
        {
            action.performed += this.OnActionPerformed;
        }

        public void UnsubscribeFromAction(InputAction action)
        {
            action.performed -= this.OnActionPerformed;
        }

        private void OnActionPerformed(InputAction.CallbackContext context)
        {
            var action = context.action;
            this.UnsubscribeFromAction(action);
            
            if (this.unusedActions.Contains(action))
            {
                this.unusedActions.Remove(action);
            }

            var entry = this.entries
                .FirstOrDefault(e => e.InputActionReference.action == action);

            if (entry != null)
            {
                var prompt = entry.Prompt;

                if (prompt != null)
                {
                    prompt.Hide();
                }
            }

            if (this.unusedActions.Any())
            {
                this.interval.Reset();
                this.interval.Start();
            }
        }
        
        private void OnIntervalElapsed(IInterval obj)
        {
            if (!this.unusedActions.Any())
            {
                return;
            }

            var action = this.unusedActions.First();
            var prompt = this.entries
                .Where(entry => entry.InputActionReference.action == action)
                .Select(entry => entry.Prompt)
                .FirstOrDefault();

            if (prompt != null)
            {
                prompt.Show();
            }
        }
    }
}
