using System;
using TMPro;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.UI
{
  public class DamageNumberSetup : MonoBehaviour
  {
    private bool active;
    private TextMeshPro text;
    [SerializeField]
    private float aliveTimeMax;
    private float aliveTime;
    private Color thisColor;
    private float colorAlpha;
    private float posY;
    public void Setup(float damage, Color color)
    {
      this.text = this.GetComponent<TextMeshPro>();
      if(damage>= 0)//damaged
      {
        this.text.SetText($"-{MathF.Abs(damage).ToString()}");
      }
      if(damage<=0)//healed
      {
        this.text.SetText($"+{MathF.Abs(damage).ToString()}");
      }

      this.text.color = color;
      this.thisColor = color;
      this.active = true;
      this.aliveTime = this.aliveTimeMax;
      this.colorAlpha = this.text.color.a;
      this.posY = this.transform.position.y;
    }

    private void Update()
    {
      if(this.active)
      {
        this.aliveTime -= Time.deltaTime; 
        var t = this.aliveTime/ this.aliveTimeMax;
        //changes the alpha value of the gradually over the number's lifetime. 
        this.text.color = new Color(this.thisColor.r, this.thisColor.g, this.thisColor.b,Mathf.Lerp(this.colorAlpha/4, this.colorAlpha, t));
        var thisScale = Mathf.Lerp(1.5f,1f,t);
        this.transform.localScale = new Vector2(thisScale,thisScale);
        this.transform.position = new Vector2(this.transform.position.x, Mathf.Lerp(this.posY +1f, this.posY, t));
        if(this.aliveTime <= 0)
        {
          Destroy(this.gameObject);
        }

      }
    }
  
  }
}
