using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System.Numerics;
using System.Xml.Linq;
namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string userName;
        private int followers;
        private List<string> participations;

        public Influencer(string username, int followers, double engagementRate)
        {
            Username = username;
            Followers = followers;
            EngagementRate = engagementRate;
            Income = 0;
            participations = new List<string>();
        }

        public string Username
        {
            get => userName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username is required.");
                }
                userName = value;
            }
        }


        public int Followers
        {
            get => followers;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Followers count cannot be a negative number.");
                }
                followers = value;
            }
        }


        public double EngagementRate { get; private set; }


        public double Income { get; private set; }

        public IReadOnlyCollection<string> Participations
        {
            get { return participations.AsReadOnly(); }
        }

        public abstract int CalculateCampaignPrice();

        public void EarnFee(double amount)
        {
            Income += amount;
        }

        public void EndParticipation(string brand)
        {
            participations.Remove(brand);
        }

        public void EnrollCampaign(string brand)
        {
            participations.Add(brand);
        }

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }
    }
}
