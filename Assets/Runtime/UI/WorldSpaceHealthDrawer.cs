using System;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI
{
    public class WorldSpaceHealthDrawer : MonoBehaviour
    {
        [SerializeField]
        private HealthRegistrar registrar;
        [SerializeField]
        private GameObject prefab;
        private Dictionary<HealthHandler, GameObject> prefabInstances;

        private void Awake()
        {
            this.prefabInstances = new Dictionary<HealthHandler, GameObject>();
            this.registrar.Setup();
        }

        private void OnEnable()
        {
            this.registrar.Registered += this.OnRegistered;
            this.registrar.Deregistered += this.OnDeregistered;
        }

        private void OnDisable()
        {
            this.registrar.Registered -= this.OnRegistered;
            this.registrar.Deregistered -= this.OnDeregistered;
        }
        
        private void OnRegistered(HealthHandler handler)
        {
            if (this.prefabInstances.TryGetValue(handler, out var prefabInstance))
            {
                prefabInstance.SetActive(true);
            }
            else
            {
                var instance = Instantiate(this.prefab, this.transform);

                if (instance.TryGetComponent<HealthDrawer>(out var healthDrawer))
                {
                    healthDrawer.BindTo(handler);
                }

                if (instance.TryGetComponent<AttachToWorldSpaceObject>(out var attachBehaviour))
                {
                    attachBehaviour.ObjectToFollow = handler.transform;
                }

                this.prefabInstances.Add(handler, instance);
            }
        }
        
        private void OnDeregistered(HealthHandler handler)
        {
            if (!this.prefabInstances.ContainsKey(handler))
            {
                return;
            }

            var instance = this.prefabInstances[handler];
            instance.SetActive(false);
        }
    }
}
