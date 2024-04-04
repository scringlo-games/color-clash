using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class SetObjectAsChildWhileRunning : MonoBehaviour
    {
        [SerializeField]
        private  string targetName;
        private GameObject target;
        void OnEnable()
        {
            StartCoroutine(SceneCheck());
        }
        IEnumerator SceneCheck()
        {
            if(GameObject.Find(targetName) != null)
            {
                target = GameObject.Find(targetName);
                this.target.transform.parent = this.gameObject.transform;
                StopCoroutine(SceneCheck());
            }

            
            yield return new WaitForSeconds(0.5f);
        }
    }
}
