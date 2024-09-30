using BorderControl.Models.Interface;

namespace BorderControl.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }
        public string Id { get; private set; }


        public bool CheckUnit(string token)
        {
            return Id.EndsWith(token);
        }

    }
}
