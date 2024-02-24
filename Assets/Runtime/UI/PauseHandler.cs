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
            this.isPaused = false;
        }
        
        void OnEnable()
        {
            this.pauseToggleEvent.Raised += this.PauseToggle;
        }
        void OnDisable()
        {
            this.pauseToggleEvent.Raised -= this.PauseToggle;
        }
        public void PauseToggle()
        {    
            if(this.isPaused)
            {
                this.isPaused = false;
                this.pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else if(!this.isPaused)
            {
                this.isPaused = true;
                this.pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
