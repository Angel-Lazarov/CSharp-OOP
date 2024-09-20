using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> coughFish;
        private double competitionPoints;
        private bool hasHealthIssues;

        public Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            coughFish = new List<string>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                name = value;
            }
        }

        public int OxygenLevel
        {
            get { return oxygenLevel; }
            protected set
            {
                if (value < 0)
                {
                    oxygenLevel = 0;
                }
                else
                {
                    oxygenLevel = value;
                }
            }
        }


        public IReadOnlyCollection<string> Catch
        {
            get { return coughFish.AsReadOnly(); }
        }

        public double CompetitionPoints
        {
            get => competitionPoints;
        }

        public bool HasHealthIssues
        {
            get => hasHealthIssues;
            set
            {
                hasHealthIssues = value;
            }
        }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            coughFish.Add(fish.Name);
            competitionPoints += fish.Points;
        }
        //------------------------
        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();
        //------------------------------------------
        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }

        public override string ToString()
        {
            int count = coughFish.Count;
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {count}, Points earned: {CompetitionPoints:f1} ]".ToString();
        }
    }
}
