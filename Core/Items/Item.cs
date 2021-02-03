namespace Core.Items
{
    public abstract class Item : Obj
    {
        public abstract int GetWidth(int defaultLeftMargin, int defaultRightMargin);
    }
}