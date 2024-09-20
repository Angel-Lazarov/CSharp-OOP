namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private const string StatOutPfRangeExeptionMessage = "{0} should be between 0 and 100.";
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public int Endurance
        {
            get => endurance;
            private set
            {
                if (CheckStatValue(value))
                {
                    throw new ArgumentException(string.Format(StatOutPfRangeExeptionMessage, nameof(Endurance)));
                }
                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            private set
            {
                if (CheckStatValue(value))
                {
                    throw new ArgumentException(string.Format(StatOutPfRangeExeptionMessage, nameof(Sprint)));
                }
                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                if (CheckStatValue(value))
                {
                    throw new ArgumentException(string.Format(StatOutPfRangeExeptionMessage, nameof(Dribble)));
                }
                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                if (CheckStatValue(value))
                {
                    throw new ArgumentException(string.Format(StatOutPfRangeExeptionMessage, nameof(Passing)));
                }
                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            private set
            {
                if (CheckStatValue(value))
                {
                    throw new ArgumentException(string.Format(StatOutPfRangeExeptionMessage, nameof(Shooting)));
                }
                shooting = value;
            }
        }

        public double SkillLevel
        {
            //get => Math.Round((Endurance + Sprint + Dribble + Passing + Shooting) / 5d);
            get => (Endurance + Sprint + Dribble + Passing + Shooting) / 5d;
        }

        private bool CheckStatValue(int stat) => stat < 0 || stat > 100;



    }
}