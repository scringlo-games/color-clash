using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.Shared.GameObjectFilters;
using UnityEngine;

public class EnableBehaviorsPastHealthThreshold : MonoBehaviour
{
    [SerializeField]
    private float healthThreshold01;
    [SerializeField]
    private HealthHandler healthHandler;
    [SerializeField]
    private List<Behaviour> behaviours= new List<Behaviour>();
    [SerializeField]
    private DamageArgsEvent damagedArgsEvent;
    [SerializeField]
    private GameObjectFilterSet filter;
    private float maxHealth;
    
    void OnEnable()
    {
        damagedArgsEvent.Raised += CheckHealth;
        maxHealth = healthHandler.MaxHealth;
    }
    void OnDisable()
    {
        damagedArgsEvent.Raised -= CheckHealth;
    }
    void CheckHealth(DamageArgs args)
    {
        if(healthHandler.Health <= maxHealth * healthThreshold01 && filter.Evaluate(args.Receiver.gameObject))
        {
            foreach(Behaviour behaviour in behaviours)
            {
                behaviour.enabled = true;
            }
        }
    }
}
