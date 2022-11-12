namespace GShock.Data
{
    public interface IButton
    {
        string Title { get; }
        void Press();
        void Release();
    }
}
