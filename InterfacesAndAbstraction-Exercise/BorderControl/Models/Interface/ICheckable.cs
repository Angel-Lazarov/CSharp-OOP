namespace BorderControl.Models.Interface
{
    public interface ICheckable
    {
        string Id { get; }
        bool CheckUnit(string token);
    }
}
