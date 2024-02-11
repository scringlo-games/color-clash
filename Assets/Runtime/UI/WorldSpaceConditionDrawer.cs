using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.UI
{
    public class WorldSpaceConditionDrawer : MonoBehaviour
    {
        [SerializeField] 
        private ConditionRegistrar registrar;
        [SerializeField]
        private GameObject prefab;
        private Dictionary<ConditionBank,GameObject> prefabInstances;
        [SerializeField]
        private float newSize;
        [FormerlySerializedAs("Offset")]
        [SerializeField]
        private Vector2 offset; 
        [SerializeField]
        private GameObjectFilterSet filter;
        
        private void Awake()
        {
            this.prefabInstances = new Dictionary<ConditionBank, GameObject>();
            //this.registrar.Setup();
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
        private void OnRegistered(ConditionBank bank)
        {
            Debug.Log("something has been registered");
            if(bank == null)
            {
                return;
            }
            if(!this.filter.Evaluate(bank.gameObject))
            {
                return;
            }
            if(this.prefabInstances.TryGetValue(bank, out GameObject prefabInstance))
            {
                prefabInstance.SetActive(true);
            }
            else
            {
                GameObject instance = Instantiate(this.prefab, this.transform);
                RectTransform rectT = instance.GetComponent<RectTransform>();
                rectT.sizeDelta = Vector2.one * this.newSize;
                rectT.anchorMin = Vector2.one / 2f;
                rectT.anchorMax = Vector2.one / 2f;
                rectT.pivot = Vector2.one / 2f;
                if (instance.TryGetComponent<ConditionDrawer>(out var drawer))
                {
                    drawer.BindTo(bank);
                }
                if (instance.TryGetComponent<AttachToWorldSpaceObject>(out var target))
                {
                    target.ObjectToFollow = bank.transform;
                    target.Offset = this.offset;

                }

                this.prefabInstances.Add(bank, instance);

            }
        }
        private void OnDeregistered(ConditionBank bank)
            {
                if (!this.filter.Evaluate(bank.gameObject))
                {
                    return;
                }
                
                if (!this.prefabInstances.ContainsKey(bank))
                {
                    return;
                }

                var instance = this.prefabInstances[bank];
                instance.SetActive(false);
            }
        }
}