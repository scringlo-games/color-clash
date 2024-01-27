using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public int health { get; private set; }
    [field: SerializeField]
    public int maxHealth {get; private set;} = 100;
    public event Action<int> OnHealthChanged;
    
    
    
  
    void Start()
    {
        //sets health to max health on the first frame of the player existing. 
        health = maxHealth;
    }
    void TakeDamage(int dmg)
    {
        //checks if health is above 0 before dealing damage.
        if (health > 0)
        {
            //subtracts the dmg amount from health, then invokes the currenHealth event, passing health.
            this.health -= dmg;
            OnHealthChanged?.Invoke(this.health);
        }
    }
    
    void Heal(int healAmount)
    {
        //adds health to the health variable
        this.health += healAmount;
        OnHealthChanged?.Invoke(this.health);
    }

}

