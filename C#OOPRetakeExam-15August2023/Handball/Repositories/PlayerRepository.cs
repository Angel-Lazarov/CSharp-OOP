using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;

        public PlayerRepository()
        {
            models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => models.AsReadOnly();

        public void AddModel(IPlayer model)
        {
            models.Add(model);
        }

        public bool ExistsModel(string name)
        {
           return models.Any(x => x.Name == name);
        }

        public IPlayer GetModel(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveModel(string name)
        {
            //IPlayer model = models.FirstOrDefault(x => x.Name == name);
            // return models.Remove(model);
            return models.Remove(models.FirstOrDefault(x => x.Name == name));

            //IPlayer model = GetModel(name);
            //return models.Remove(model);
        }
    }
}
