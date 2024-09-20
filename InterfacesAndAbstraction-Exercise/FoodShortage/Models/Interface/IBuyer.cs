namespace FoodShortage.Models.Interface
{
    public interface IBuyer : INameable
    {
        int Food { get; }
        void BuyFood();
    }
}
