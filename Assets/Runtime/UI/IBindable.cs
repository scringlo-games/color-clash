namespace ScringloGames.ColorClash.Runtime.UI
{
    public interface IBindable<T>
    {
        T BoundTo { get; }

        void Bind(T obj);
        void Unbind();
    }
}
