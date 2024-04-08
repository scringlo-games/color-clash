using System.Collections.Generic;
using TravisRFrench.Common.Runtime.Registration;

namespace ScringloGames.ColorClash.Runtime.Spawning
{
    public class SpawnPointRegistrar : Registrar<SpawnPoint>
    {
        public new IEnumerable<SpawnPoint> Entities => base.Entities;
    }
}
