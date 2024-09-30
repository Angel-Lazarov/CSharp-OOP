
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fish;

        public Controller()
        {
            divers = new();
            fish = new();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) == null)
            {
                return string.Format(OutputMessages.DiverNotFound, typeof(DiverRepository).Name, diverName);
            }
            if (fish.GetModel(fishName) == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }
            if (divers.GetModel(diverName).HasHealthIssues) //??????????
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }
            if (divers.GetModel(diverName).OxygenLevel < fish.GetModel(fishName).TimeToCatch)
            {
                divers.GetModel(diverName).Miss(fish.GetModel(fishName).TimeToCatch);

                if (divers.GetModel(diverName).OxygenLevel <= 0)
                {
                    divers.GetModel(diverName).UpdateHealthStatus();
                }

                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            if (divers.GetModel(diverName).OxygenLevel == fish.GetModel(fishName).TimeToCatch)
            {
                if (isLucky)
                {
                    divers.GetModel(diverName).Hit(fish.GetModel(fishName));

                    if (divers.GetModel(diverName).OxygenLevel <= 0)
                    {
                        divers.GetModel(diverName).UpdateHealthStatus();
                    }

                    return string.Format(OutputMessages.DiverHitsFish, diverName, fish.GetModel(fishName).Points, fishName);
                }
                else
                {
                    divers.GetModel(diverName).Miss(fish.GetModel(fishName).TimeToCatch);

                    if (divers.GetModel(diverName).OxygenLevel <= 0)
                    {
                        divers.GetModel(diverName).UpdateHealthStatus();
                    }

                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }
            divers.GetModel(diverName).Hit(fish.GetModel(fishName));

            if (divers.GetModel(diverName).OxygenLevel <= 0)
            {
                divers.GetModel(diverName).UpdateHealthStatus();
            }

            return string.Format(OutputMessages.DiverHitsFish, diverName, fish.GetModel(fishName).Points, fishName);
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var diver in divers.Models.OrderByDescending(d => d.CompetitionPoints).ThenByDescending(d => d.Catch.Count).ThenBy(d => d.Name).Where(d => d.HasHealthIssues == false))
            {

                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();

        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != typeof(FreeDiver).Name && diverType != typeof(ScubaDiver).Name)
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (divers.Models.Any(d => d.Name == diverName))
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, typeof(DiverRepository).Name);
            }

            if (diverType == typeof(FreeDiver).Name)
            {
                divers.AddModel(new FreeDiver(diverName));

            }
            else if (diverType == typeof(ScubaDiver).Name)
            {
                divers.AddModel(new ScubaDiver(diverName));

            }

            return string.Format(OutputMessages.DiverRegistered, diverName, typeof(DiverRepository).Name);

        }
        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(divers.GetModel(diverName).ToString());
            sb.AppendLine("Catch Report:");
            IDiver diver = divers.GetModel(diverName);

            foreach (string item in diver.Catch)
            {
                IFish f = fish.GetModel(item);

                sb.AppendLine(f.ToString());
            }

            return sb.ToString().Trim();
        }

        public string HealthRecovery()
        {
            int count = 0;

            foreach (Diver diver in divers.Models.Where(d => d.HasHealthIssues == true))
            {
                diver.HasHealthIssues = false;
                diver.RenewOxy();
                count++;
            }

            return string.Format(OutputMessages.DiversRecovered, count);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != typeof(PredatoryFish).Name && fishType != typeof(DeepSeaFish).Name && fishType != typeof(ReefFish).Name)
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (fish.Models.Any(d => d.Name == fishName))
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, typeof(FishRepository).Name);
            }

            if (fishType == typeof(PredatoryFish).Name)
            {
                fish.AddModel(new PredatoryFish(fishName, points));
            }

            else if (fishType == typeof(DeepSeaFish).Name)
            {
                fish.AddModel(new DeepSeaFish(fishName, points));
            }

            else if (fishType == typeof(ReefFish).Name)
            {
                fish.AddModel(new ReefFish(fishName, points));
            }

            return string.Format(OutputMessages.FishCreated, fishName);

        }


    }

}
