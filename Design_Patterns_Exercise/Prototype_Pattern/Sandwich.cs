namespace Prototype_Pattern;

public class Sandwich : SandwichPrototype
{
    private string bread;
    private string meat;
    private string cheese;
    private string veggies;

    public Sandwich(string bread, string meat, string cheese, string veggies)
    {
        this.bread = bread;
        this.meat = meat;
        cheese = cheese;
        this.veggies = veggies;
    }

    public override SandwichPrototype Clone()
    {
        string ingredientsList = GetIngredients();
        Console.WriteLine($"Cloning sandwich with ingredients {ingredientsList}");

        return MemberwiseClone() as SandwichPrototype;

    }

    private string GetIngredients() 
    {
        return $"{bread}, {meat}, {cheese}, {veggies}";
    }
}
