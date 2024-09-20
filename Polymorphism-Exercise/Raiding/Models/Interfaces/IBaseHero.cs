namespace Raiding.Models.Interfaces
{
    public interface IBaseHero
    {
        string Name { get; }  
        string Type { get; }
        int Power { get; }

        abstract string CastAbility();
    }
}
