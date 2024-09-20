using MilitaryElite.Core.Interfaces;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private Dictionary<string, ISoldier> soldiers;

        public Engine()
        {
            soldiers = new Dictionary<string, ISoldier>();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(ProcessInput(tokens));
                }
                catch (Exception ex) { }
            }
        }

        private string ProcessInput(string[] tokens)
        {
            string soldierType = tokens[0];
            string id = tokens[1];
            string firstName = tokens[2];
            string lastName = tokens[3];

            ISoldier soldier = null;

            switch (soldierType)
            {
                case "Private":

                    soldier = GetPrivate(id, firstName, lastName, decimal.Parse(tokens[4]));
                    break;

                case "Spy":

                    soldier = GetSpy(id, firstName, lastName, int.Parse(tokens[4]));
                    break;

                case "LieutenantGeneral":

                    soldier = GetLieutenantGeneral(id, firstName, lastName, tokens);
                    break;

                case "Engineer":

                    soldier = GetEngineer(id, firstName, lastName, tokens);
                    break;

                case "Commando":

                    soldier = GetCommando(id, firstName, lastName, tokens);
                    break;


            }

            soldiers.Add(id, soldier);

            return soldier.ToString();
        }

        private ISoldier GetCommando(string id, string firstName, string lastName, string[] tokens)
        {
            decimal salary = decimal.Parse(tokens[4]);

            bool isValidCorps = Enum.TryParse<Corps>(tokens[5], out Corps corps);

            if (!isValidCorps)
            {
                throw new Exception();
            }

            List<IMission> missions = new List<IMission>();

            for (int i = 6; i < tokens.Length; i += 2)
            {
                string missionName = tokens[i];
                string missionState = tokens[i + 1];

                bool isValidMission = Enum.TryParse<State>(missionState, out State state);

                if (!isValidMission)
                {
                    continue;
                }
                IMission mission = new Mission(missionName, state);

                missions.Add(mission);
            }

            return new Commando(id, firstName, lastName, salary, corps, missions);
        }

        private ISoldier GetEngineer(string id, string firstName, string lastName, string[] tokens)
        {
            decimal salary = decimal.Parse(tokens[4]);

            bool isValidCorps = Enum.TryParse<Corps>(tokens[5], out Corps corps);

            if (!isValidCorps)
            {
                throw new Exception();
            }

            List<IRepair> repairs = new List<IRepair>();

            for (int i = 6; i < tokens.Length; i += 2)
            {
                IRepair repair = new Repair(tokens[i], int.Parse(tokens[i + 1]));

                repairs.Add(repair);
            }

            return new Engineer(id, firstName, lastName, salary, corps, repairs);
        }

        private ISoldier GetLieutenantGeneral(string id, string firstName, string lastName, string[] tokens)
        {
            decimal salary = decimal.Parse(tokens[4]);

            List<IPrivate> privatesOnDuty = new List<IPrivate>();

            for (int i = 5; i < tokens.Length; i++)
            {
                string soldierId = tokens[i];
                IPrivate soldier = (IPrivate)soldiers[soldierId];
                privatesOnDuty.Add(soldier);
            }

            return new LieutenantGeneral(id, firstName, lastName, salary, privatesOnDuty);
        }

        private ISoldier GetSpy(string id, string firstName, string lastName, int codeNumber) => new Spy(id, firstName, lastName, codeNumber);

        private ISoldier GetPrivate(string id, string firstName, string lastName, decimal salary) => new Private(id, firstName, lastName, salary);
    }
}

