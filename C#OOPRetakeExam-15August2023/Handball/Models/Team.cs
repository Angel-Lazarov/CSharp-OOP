using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handball.Models
{
    public class Team : ITeam
    {

        private string name;
        private int pointsEarned; // by default = 0
        private List<IPlayer> players;

        public Team(string name)
        {
            Name = name;
            players = new List<IPlayer>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }

        public int PointsEarned
        {
            get => pointsEarned;
            private set { pointsEarned = value; }
        }


        public double OverallRating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                return Math.Round(players.Average(p => p.Rating), 1);
            }
        }

        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void Draw()
        {
            PointsEarned += 1;

            IPlayer goalKeeper = players.FirstOrDefault(p => p.GetType().Name == "Goalkeeper");
            goalKeeper.IncreaseRating();
        }

        public void Lose()
        {
            foreach (var player in players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;
            foreach (var player in players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");


            string playerNames = "none";
            if (players.Count > 0)
            {
                playerNames = string.Join(", ", players.Select(p => p.Name));
            }
            sb.Append($"--Players: {playerNames}");


            //List<string> playerNames = new List<string>();

            //foreach (var player in players)
            //{
            //    playerNames.Add(player.Name);
            //}

            //if (playerNames.Any())
            //{
            //    sb.AppendLine(string.Join(", ", playerNames));
            //}
            //else
            //{
            //    sb.AppendLine("none");
            //}

            return sb.ToString().Trim();
        }
    }
}
