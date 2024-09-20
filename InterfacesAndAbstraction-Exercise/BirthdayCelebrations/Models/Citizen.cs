using BirthdayCelebrations.Models.Interface;

namespace BirthdayCelebrations.Models
{
    public class Citizen : IBirthable, INameable, IIdentifiable
    {
        public Citizen(string name, string age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Id { get; private set; }
        public string BirthDate { get; private set; }

    }
}
