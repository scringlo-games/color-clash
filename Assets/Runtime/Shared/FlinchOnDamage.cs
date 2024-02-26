using ScringloGames.ColorClash.Runtime.Damage;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class FlinchOnDamage : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer sprite;
        [SerializeField]
        [Range(0.05f,1f)]
        private float flashLengthMax;
        [SerializeField]
        [Range(0,1)]
        private float flashIntensity;
        [SerializeField]
        private Color flashColor;
        [SerializeField]
        [Range(0f,0.20f)]
        private float flinchScaleIntensity;
        [SerializeField]
        private DamageArgsEvent damagedEvent;
        private Vector2 startScale;
        private Vector2 modScale;
        private Color startColor;
        private Color lerpedColor;
        private float flashLength;
        private bool isFlashing;
        
        private void OnEnable()
        {
            var size = this.sprite.transform.localScale;
            this.startScale = size;
            this.modScale = new Vector2(size.x - (this.flinchScaleIntensity * size.x),size.y - (this.flinchScaleIntensity * size.y));
            this.startColor = this.sprite.color;
            this.lerpedColor = Color.Lerp(this.startColor, this.flashColor, this.flashIntensity);
            
            this.damagedEvent.Raised += this.OnDamaged;
        }

        private void OnDisable()
        {
            this.damagedEvent.Raised -= this.OnDamaged;
        }

        private void Update()
        {
            if(this.isFlashing)
            {
                this.flashLength -= Time.deltaTime;
                
                if(this.flashLength <= 0 )
                {
                    this.sprite.color = this.startColor;
                    this.sprite.transform.localScale = this.startScale;
                    this.isFlashing = false;
                }
            }
        }

        private void Flinch()
        {  
            this.isFlashing = true;
            this.sprite.color = this.lerpedColor;
            this.sprite.transform.localScale = this.modScale;
            this.flashLength = this.flashLengthMax;
        }
        
        private void OnDamaged(DamageArgs args)
        {
            if (args.Receiver.gameObject != this.gameObject)
            {
                return;
            }
            
            this.Flinch();
        }
    }
}
