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
    [SerializeField][Range(0f,0.20f)]
    private float flinchScaleIntensity;
    private UnityEngine.Vector2 startScale;
    private UnityEngine.Vector2 modScale;
    private Color startColor;
    private Color lerpedColor;
    private float flashLength;
    private bool isFlash;
    void Start()
    {
        startScale = this.sprite.size;
        modScale = new UnityEngine.Vector2(this.sprite.size.x - (flinchScaleIntensity * this.sprite.size.x),this.sprite.size.y - (flinchScaleIntensity*this.sprite.size.y));
        Debug.Log($"mod scale is {modScale}");
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
                this.sprite.size = startScale;
                isFlash = false;
            }
        }
    }
    void Flinch(int currentHealth)
    {  
            isFlash = true;
            this.sprite.color = lerpedColor;
            this.sprite.size = modScale;
            flashLength = flashLengthMax;
        
    }
}
