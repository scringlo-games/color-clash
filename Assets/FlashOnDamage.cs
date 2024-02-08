using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.UI;
using UnityEngine;

public class FlashOnDamage : MonoBehaviour
{
    [SerializeField]
    private HealthHandler health;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField][Range(0.05f,1f)]
    private float flashLength;
    [SerializeField]
    private float flashIntensity;
    [SerializeField]
    private Color flashColor;
    void OnEnable()
    {
        health.HealthChanged += Flinch;
    }
    void OnDisable()
    {
        health.HealthChanged -= Flinch;
    }
    void Update()
    {

    }
    void Flinch(int currentHealth)
    {
        
    }
}
