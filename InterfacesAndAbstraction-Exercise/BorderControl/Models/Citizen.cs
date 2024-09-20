using BorderControl.Models.Interface;

namespace BorderControl.Models
{
    public class Citizen : ICheckable
    {
        public Citizen(string name, string age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Id { get; private set; }

        public bool CheckUnit(string token)
        {
            return Id.EndsWith(token);
        }

    }
}
