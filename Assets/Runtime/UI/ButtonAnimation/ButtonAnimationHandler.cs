using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ScringloGames.ColorClash.Runtime.MainCamera;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace ScringloGames.ColorClash.Runtime
{
    public class ButtonAnimationHandler : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField]
        private RectTransform button;
        [SerializeField]
        private float scaleAmount = 1.1f;
        [SerializeField]
        private float scaleDuration = 0.2f;
        [SerializeField]
        private AnimationCurve animCurve;
       
        public void OnSelect(BaseEventData eventData)
        {
           
            button.DOScale(scaleAmount, scaleDuration)
            .SetEase(animCurve)
            .SetAutoKill(false);   
        }
        
        
    
        public void OnDeselect(BaseEventData eventData)
        {
            DOTween.PlayBackwards(button);
            
            
        } 
        public void DeselectAll(BaseEventData eventData)
        {
            GameObject.Find("EventSystem").GetComponent<EventSystem>()
            .SetSelectedGameObject(null);
        }
    


    }
}
