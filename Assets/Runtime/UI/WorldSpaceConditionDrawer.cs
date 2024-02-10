using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ScringloGames.ColorClash.Runtime;
using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using ScringloGames.ColorClash.Runtime.UI;
using UnityEngine;

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
        [SerializeField]
        private Vector2 Offset; 
        [SerializeField]
        private GameObjectFilterSet filter;
        
        private void Awake()
        {
            this.prefabInstances = new Dictionary<ConditionBank, GameObject>();
            //this.registrar.Setup();
        }
        private void OnEnable()
        {
            this.registrar.Registered += OnRegistered;
            this.registrar.Deregistered += OnDeregistered;
        }
        private void OnDisable()
        {
            this.registrar.Registered -= OnRegistered;
            this.registrar.Deregistered -= OnDeregistered;
        }
        private void OnRegistered(ConditionBank bank)
        {
            Debug.Log("something has been registered");
            if(bank == null)
            {
                return;
            }
            if(!filter.Evaluate(bank.gameObject))
            {
                return;
            }
            if(prefabInstances.TryGetValue(bank, out GameObject prefabInstance))
            {
                prefabInstance.SetActive(true);
            }
            else
            {
                GameObject instance = Instantiate(prefab, this.transform);
                RectTransform rectT = instance.GetComponent<RectTransform>();
                rectT.sizeDelta = Vector2.one * newSize;
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
                    target.Offset = this.Offset;

                }
                prefabInstances.Add(bank, instance);

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