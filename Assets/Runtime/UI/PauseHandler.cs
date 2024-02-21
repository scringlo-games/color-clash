using System.Collections;
using System.Collections.Generic;
using TravisRFrench.Common.Runtime.ScriptableEvents;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class PauseHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject pauseMenu;
        [SerializeField]
        private ScriptableEvent pauseToggleEvent;
        private bool isPaused;
        void Awake()
        {
            isPaused = false;
        }
        
        void OnEnable()
        {   
            pauseToggleEvent.Raised += PauseToggle;
        }
        void OnDisable()
        {
            pauseToggleEvent.Raised -= PauseToggle;
        }
        public void PauseToggle()
        {    
            if(isPaused)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else if(!isPaused)
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
