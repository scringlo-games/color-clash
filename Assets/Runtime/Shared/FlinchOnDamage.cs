using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
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
        private Vector2 startScale;
        private Vector2 modScale;
        private Color startColor;
        private Color lerpedColor;
        private float flashLength;
        private bool isFlash;

        private void Start()
        {
            var size = this.sprite.size;
            this.startScale = size;
            this.modScale = new Vector2(size.x - (this.flinchScaleIntensity * size.x),size.y - (this.flinchScaleIntensity * size.y));
            Debug.Log($"mod scale is {this.modScale}");
            this.startColor = this.sprite.color;
            this.lerpedColor = Color.Lerp(this.startColor, this.flashColor, this.flashIntensity);
        }

        private void OnEnable()
        {
            this.health.HealthChanged += this.Flinch;
        }

        private void OnDisable()
        {
            this.health.HealthChanged -= this.Flinch;
        }

        private void Update()
        {   if(this.isFlash)
            {
                this.flashLength -= Time.deltaTime;
                if(this.flashLength <= 0 )
                {
                    this.sprite.color = this.startColor;
                    this.sprite.transform.localScale = this.startScale;
                    this.isFlash = false;
                }
            }
        }

        private void Flinch(int currentHealth)
        {  
            this.isFlash = true;
            this.sprite.color = this.lerpedColor;
            this.sprite.transform.localScale = this.modScale;
            this.flashLength = this.flashLengthMax;
        }
    }
}
