using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class ReplaceSprite : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private Sprite replacementSprite;
        void OnEnable()
        {
            spriteRenderer.sprite = replacementSprite;
        }
    }
}
