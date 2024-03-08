using ScringloGames.ColorClash.Runtime.Shared.ScriptableVariables;
using UnityEngine;

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
            this.variable.Value = this.objectToAssign;
        }
    }
}
