namespace Prototype_Pattern;

public class SandwichMenu
{
    private IDictionary<string, SandwichPrototype> sandwiches = new Dictionary<string, SandwichPrototype>();


    public SandwichPrototype this[string name]
    {
        get => sandwiches[name]; 
        set
        { 
            sandwiches.Add(name, value);
        }
    }
}
