namespace Core.Items
{
    public abstract class Item : Obj
    {
        public abstract int MaxWidth { get; protected set; }
    }
}