namespace NauticalCatchChallenge.Models
{
    internal class ScubaDiver : Diver
    {
        private const int baseOxigen = 540;

        public ScubaDiver(string name) : base(name, baseOxigen)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.3, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = baseOxigen;
        }
    }
}
