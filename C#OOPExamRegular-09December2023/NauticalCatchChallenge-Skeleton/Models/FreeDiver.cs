
namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int baseOxigen = 120;

        public FreeDiver(string name) : base(name, baseOxigen)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero);

        }

        public override void RenewOxy()
        {
            OxygenLevel = baseOxigen;
        }
    }
}
