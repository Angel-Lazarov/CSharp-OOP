namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double CaloriesPerGram = 2;

        private Dictionary<string, double> flourModifier;
        private Dictionary<string, double> bakingTechniqueModifier;

        private string flourType;
        private string bakingTechnique;
        private double weigh;

        public Dough(string flourType, string bakingTechniqye, double weigh)
        {
            flourModifier = new Dictionary<string, double>() { { "white", 1.5 }, { "wholegrain", 1.0 } };
            bakingTechniqueModifier = new Dictionary<string, double>() { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };
            Weigh = weigh;
            BakingTechniqye = bakingTechniqye;
            FlourType = flourType;
        }

        public double Weigh
        {
            get { return weigh; }
            private set
            {
                if (value < 1 || value > 200)
                { throw new Exception("Dough weight should be in the range [1..200]."); }
                weigh = value;
            }
        }

        public string BakingTechniqye
        {
            get { return bakingTechnique; }
            private set
            {
                if (!bakingTechniqueModifier.ContainsKey(value.ToLower()))
                { throw new Exception("Invalid type of dough."); }

                bakingTechnique = value.ToLower();
            }
        }


        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (!flourModifier.ContainsKey(value.ToLower()))
                { throw new Exception("Invalid type of dough."); }

                flourType = value.ToLower();
            }
        }

        public double Calories
        {
            get
            {
                double flourMod = flourModifier[FlourType];
                double bakingMod = bakingTechniqueModifier[bakingTechnique];

                return CaloriesPerGram * Weigh * flourMod * bakingMod;
            }
        }
    }
}
