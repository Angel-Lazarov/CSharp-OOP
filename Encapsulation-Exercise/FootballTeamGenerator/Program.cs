using FootballTeamGenerator.Models;

namespace FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(";");
                string command = tokens[0];

                try
                {
                    if (command == "Team")
                    {
                        Team team = new Team(tokens[1]);
                        teams.Add(team);
                    }
                    else if (command == "Add")
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == tokens[1]);

                        if (team == null)
                        {
                            throw new Exception($"Team {tokens[1]} does not exist.");
                        }

                        Player player = new(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));

                        team.AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == tokens[1]);

                        if (team == null)
                        {
                            throw new Exception($"Team {tokens[1]} does not exist.");
                        }

                        team.RemovePlayer(tokens[2]);
                    }
                    else if (command == "Rating")
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == tokens[1]);

                        if (team == null)
                        {
                            throw new Exception($"Team {tokens[1]} does not exist.");
                        }

                        Console.WriteLine($"{team.Name} - {team.Rating:f0}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
