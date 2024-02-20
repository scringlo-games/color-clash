using System;
using TMPro;
using UnityEngine;

public class DamageNumberSetup : MonoBehaviour
{
  private bool active;
  private TextMeshPro text;
  [SerializeField]
  float aliveTimeMax;
  float aliveTime;
  Color thisColor;
  float colorAlpha;
  float posY;
  public void Setup(float damage, Color color)
  {
    text = GetComponent<TextMeshPro>();
    if(damage>= 0)//damaged
    {
      text.SetText($"-{MathF.Abs(damage).ToString()}");
    }
    if(damage<=0)//healed
    {
      text.SetText($"+{MathF.Abs(damage).ToString()}");
    }
    text.color = color;
    thisColor = color;
    active = true;
    aliveTime = aliveTimeMax;
    colorAlpha = text.color.a;
    posY = transform.position.y;
  }
  void Update()
  {
    if(active)
    {
      aliveTime -= Time.deltaTime; 
      float t = aliveTime/aliveTimeMax;
      //changes the alpha value of the gradually over the number's lifetime. 
      text.color = new Color(thisColor.r,thisColor.g,thisColor.b,Mathf.Lerp(colorAlpha/4, colorAlpha, t));
      float thisScale = Mathf.Lerp(1.5f,1f,t);
      transform.localScale = new Vector2(thisScale,thisScale);
      transform.position = new Vector2(transform.position.x, Mathf.Lerp(posY +1f, posY, t));
      if(aliveTime <= 0)
      {
        Destroy(this.gameObject);
      }

    }
  }
  
}
