
using System.Linq;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private const string PlayerNotFoundExceptionMessage = "Player {0} is not in {1} team.";
        private List<Player> players = new List<Player>();

        private string name;

        public Team(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public double Rating
        {
            get
            {
                if (players.Any())
                {
                    //return players.Sum(p => p.SkillLevel) / players.Count;
                    return players.Average(p => p.SkillLevel);
                }
                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);

            if (player is null)
            {
                throw new Exception(string.Format(PlayerNotFoundExceptionMessage, playerName, Name));
            }

            players.Remove(player);
        }
    }
}
