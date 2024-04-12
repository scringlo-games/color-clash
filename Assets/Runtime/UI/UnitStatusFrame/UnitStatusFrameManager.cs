using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using ScringloGames.ColorClash.Runtime.UI.UnitStatusFrame.Conditions;
using ScringloGames.ColorClash.Runtime.UI.UnitStatusFrame.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI.UnitStatusFrame
{
    public class UnitStatusFrameManager : MonoBehaviour
    {
        [SerializeField]
        private UnitStatusFrameDrawer framePrefab;
        [Header("Registrars")]
        [SerializeField]
        private HealthRegistrar healthRegistrar;
        [SerializeField]
        private ConditionBankRegistrar conditionBankRegistrar;
        [SerializeField]
        private GameObjectFilterSet filter;
        private Dictionary<GameObject, UnitStatusFrameDrawer> frames;

        private void Awake()
        {
            this.frames = new Dictionary<GameObject, UnitStatusFrameDrawer>();
        }

        private void OnEnable()
        {
            // We are monitoring the registrars for registration changes in the components that ANY of our UI elements
            // care about so that when any of them gets registered or deregistered we can generate UI for all of them
            // and just disable the parts that aren't applicable. This gives us the ability to change the unit status
            // UI as one element to fine-tune how it looks more easily and also makes it so we don't have to instantiate
            // each part of the UI separately.
            
            this.healthRegistrar.Registered += this.OnHealthHandlerRegistered;
            this.healthRegistrar.Deregistered += this.OnHealthHandlerDeregistered;
            this.conditionBankRegistrar.Registered += this.OnConditionBankRegistered;
            this.conditionBankRegistrar.Deregistered += this.OnConditionBankDeregistered;
        }

        private void OnDisable()
        {
            this.healthRegistrar.Registered -= this.OnHealthHandlerRegistered;
            this.healthRegistrar.Deregistered -= this.OnHealthHandlerDeregistered;
            this.conditionBankRegistrar.Registered -= this.OnConditionBankRegistered;
            this.conditionBankRegistrar.Deregistered -= this.OnConditionBankDeregistered;
        }
        
        private UnitStatusFrameDrawer GetFrame(GameObject gameObject)
        {
            if (this.frames.TryGetValue(gameObject, out var drawer))
            {
                drawer.gameObject.SetActive(true);
                
                return drawer;
            }
            else
            {
                var frameDrawer = Instantiate(this.framePrefab, this.transform);
                this.frames.Add(gameObject, frameDrawer);
                
                frameDrawer.gameObject.SetActive(true);

                return frameDrawer;
            }
        }
        
        private UnitStatusFrameDrawer GetFrame<TComponent>(TComponent component) 
            where TComponent : Component
        {
            return this.GetFrame(component.gameObject);
        }

        private bool PassesFilter(GameObject gameObject)
        {
            return this.filter.Evaluate(gameObject);
        }

        private bool PassesFilter<TComponent>(TComponent component)
            where TComponent : Component
        {
            return this.PassesFilter(component.gameObject);
        }

        private void OnHealthHandlerRegistered(HealthHandler healthHandler)
        {
            if (!this.PassesFilter(healthHandler))
            {
                return;
            }
            
            var frame = this.GetFrame(healthHandler);
            frame.gameObject.SetActive(true);
            frame.Bind(healthHandler.gameObject);

            var healthDrawer = frame.GetComponentInChildren<UnitStatusFrameHealthDrawer>(true);
            healthDrawer.Bind(healthHandler.gameObject);
        }
        
        private void OnHealthHandlerDeregistered(HealthHandler healthHandler)
        {
            if (!this.PassesFilter(healthHandler))
            {
                return;
            }
            
            var frame = this.GetFrame(healthHandler);
            frame.gameObject.SetActive(false);
            frame.Unbind();
        }
        
        private void OnConditionBankRegistered(ConditionBank conditionBank)
        {
            if (!this.PassesFilter(conditionBank))
            {
                return;
            }
            
            var frame = this.GetFrame(conditionBank);
            frame.gameObject.SetActive(true);
            frame.Bind(conditionBank.gameObject);
            
            var conditionDrawer = frame.GetComponentInChildren<UnitStatusFrameConditionDrawer>(true);
            conditionDrawer.Bind(conditionBank.gameObject);
        }
        
        private void OnConditionBankDeregistered(ConditionBank conditionBank)
        {
            if (!this.PassesFilter(conditionBank))
            {
                return;
            }
            
            var frame = this.GetFrame(conditionBank);
            frame.gameObject.SetActive(false);
            frame.Unbind();
        }
    }
}
