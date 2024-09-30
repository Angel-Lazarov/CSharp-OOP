namespace BorderControl.Models.Interface
{
    public interface IIdentifiable
    {
        string Id { get; }
        bool CheckUnit(string token);
    }
}
