using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI
{
    public class WorldSpaceHealthDrawer : MonoBehaviour
    {
        [SerializeField]
        private HealthRegistrar registrar;
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private float initialScreenSpaceRadius = 130f;
        private Dictionary<HealthHandler, GameObject> prefabInstances;
        [Tooltip("Only create UI for entities that pass this filter")]
        [SerializeField]
        private GameObjectFilterSet filter;

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
            if (handler == null)
            {
                return;
            }

            if (!this.filter.Evaluate(handler.gameObject))
            {
                return;
            }
            
            // Here we are using a temporary caching solution that will work for our purposes until we implement an
            // actual object pooling solution.

            if (this.prefabInstances.TryGetValue(handler, out var prefabInstance))
            {
                prefabInstance.SetActive(true);
            }
            else
            {
                var instance = Instantiate(this.prefab, this.transform);

                // <RANT>
                // For some silly reason Unity doesn't respect in-context RectTransform properties when instantiating
                // canvas prefabs, so here we are forcing it to use the RectTransform settings we need in order to
                // display properly.
                // I'd really like to figure out how to not force these values and instead have Unity just respect
                // the values assigned in the prefab, but the only way I know to do that is to bloat the prefab with
                // an additional canvas, which seems wasteful.
                // </RANT>
                
                var rectTransform = instance.GetComponent<RectTransform>();

                // Set the width and height to reflect the desired radius
                rectTransform.sizeDelta = Vector2.one * this.initialScreenSpaceRadius;
                
                // Center the indicator over the target position
                rectTransform.anchorMin = Vector2.one / 2f;
                rectTransform.anchorMax = Vector2.one / 2f;
                rectTransform.pivot = Vector2.one / 2f;

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
            if (!this.filter.Evaluate(handler.gameObject))
            {
                return;
            }
            
            if (!this.prefabInstances.ContainsKey(handler))
            {
                return;
            }

            var instance = this.prefabInstances[handler];
            instance.SetActive(false);
        }
    }
}
