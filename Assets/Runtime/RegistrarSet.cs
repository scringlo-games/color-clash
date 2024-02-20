using System;
using ScringloGames.ColorClash.Runtime.Conditions;
using ScringloGames.ColorClash.Runtime.Health;

namespace ScringloGames.ColorClash.Runtime
{
    [Serializable]
    public class RegistrarSet
    {
        public HealthRegistrar HealthRegistrar;
        public ConditionBankRegistrar ConditionBankRegistrar;

        public void Setup()
        {
            this.HealthRegistrar.Setup();
            this.ConditionBankRegistrar.Setup();
        }
    }
}
