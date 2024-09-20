namespace CompositePattern.Models
{
    public abstract class GiftBase
    {

        private string name;
        private decimal price;

        public GiftBase(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract decimal CalculateTottalPrice();

    }
}
