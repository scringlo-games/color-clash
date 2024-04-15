using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScringloGames.ColorClash.Runtime
{
    public class QuitOnButtonPress : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        void OnEnable()
        {
            button.onClick.AddListener(QuitGame);
        }
        void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }
        void QuitGame()
        {
            Application.Quit();
        }
    }
}
