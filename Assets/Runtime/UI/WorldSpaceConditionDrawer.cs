using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime;
using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

public class WorldSpaceConditionDrawer : MonoBehaviour
{
    [SerializeField] 
    private ConditionRegistrar condReg;
    [SerializeField]
    private GameObject prefab;
    private Dictionary<ConditionBank,GameObject> prefabInstances;
    [SerializeField]
    private float newSize;
    [SerializeField]
    private GameObjectFilterSet filter;
    
    private void Start()
    {
        prefabInstances = new Dictionary<ConditionBank, GameObject>();
        condReg.Setup();
    }
    private void OnEnable()
    {
        condReg.Registered += OnRegistered;
        condReg.Deregistered += OnDeregistered;
    }
    private void OnDisable()
    {
        condReg.Registered -= OnRegistered;
        condReg.Deregistered -= OnDeregistered;
    }
    private void OnRegistered(ConditionBank bank)
    {
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

        }
    }
    private void OnDeregistered(ConditionBank bank)
    {

    }
}
