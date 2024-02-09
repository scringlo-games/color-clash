namespace ScringloGames.ColorClash.Runtime.Shared
{
    public interface ICloneable<out TInstance>
    {
        TInstance Clone();
    }
}
