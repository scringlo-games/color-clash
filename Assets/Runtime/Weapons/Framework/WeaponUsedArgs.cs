namespace ScringloGames.ColorClash.Runtime.Weapons.Framework
{
    public class WeaponUsedArgs<TContext>
    {
        public TContext Context { get; set; }
        public IWeaponPrecondition Precondition { get; set; }
    }
}