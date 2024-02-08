using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Damage;
using ScringloGames.ColorClash.Runtime.Health;
using ScringloGames.ColorClash.Runtime.UI;
using UnityEngine;

public class FlinchOnDamage : MonoBehaviour
{
    [SerializeField]
    private HealthHandler health;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField][Range(0.05f,1f)]
    private float flashLengthMax;
    [SerializeField][Range(0,1)]
    private float flashIntensity;
    [SerializeField]
    private Color flashColor;
    [SerializeField][Range(0.75f,1f)]
    private float flinchScaleX;
    [SerializeField][Range(0.75f,1f)]
    private float flinchScaleY;
    [SerializeField][Range(0.05f, 1f)]
    private float flinchScaleLength;
    private Color startColor;
    private Color lerpedColor;
    private float flashLength;
    private bool isFlash;
    private int lastHealth;
    void Start()
    {
        lastHealth = health.Health;
        startColor = this.sprite.color;
        lerpedColor = Color.Lerp(startColor, flashColor, flashIntensity);

    }
    void OnEnable()
    {
        health.HealthChanged += Flinch;
    }
    void OnDisable()
    {
        health.HealthChanged -= Flinch;
    }
    void Update()
    {   if(isFlash)
        {
            flashLength -= Time.deltaTime;
            if(flashLength <= 0 )
            {
                this.sprite.color = startColor;
                isFlash = false;
            }
        }
    }
    void Flinch(int currentHealth)
    {   
        if(currentHealth <= lastHealth)
        {
            isFlash = true;
            sprite.color = lerpedColor;
            flashLength = flashLengthMax;
            lastHealth = currentHealth;
        }
        else 
        {
            lastHealth = currentHealth;
        }
    }
}
