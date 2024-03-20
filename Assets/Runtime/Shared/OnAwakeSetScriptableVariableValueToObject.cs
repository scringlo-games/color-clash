using System;
using ScringloGames.ColorClash.Runtime.Shared.ScriptableVariables;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public abstract class OnAwakeSetScriptableVariableValueToObject<TObject> : MonoBehaviour
        where TObject : Object
    {
        [SerializeField]
        private TObject objectToAssign;
        [SerializeField]
        private ScriptableVariable<TObject> variable;

        protected virtual void Awake()
        {
            this.SetScriptableVariableValueToObject();
        }

        protected void OnEnable()
        {
            this.SetScriptableVariableValueToObject();
        }

        private void SetScriptableVariableValueToObject()
        {
            this.variable.Value = this.objectToAssign;
        }
    }
}
