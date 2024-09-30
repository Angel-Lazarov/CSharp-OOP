using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private InfluencerRepository influencers;
        private CampaignRepository campaigns;

        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }


        public string ApplicationReport()
        {
            throw new NotImplementedException();
        }

        public string AttractInfluencer(string brand, string username)
        {
            // AttractInfluencer Nike TravelVirtu

            if (!influencers.Models.Any(i => i.Username == username))
            {
                return $"{typeof(InfluencerRepository).Name} has no {username} registered in the application.";
            }

            if (campaigns.FindByName(brand) == null)
            {
                return $"There is no campaign from {brand} in the application.";
            }

            ICampaign campain = campaigns.FindByName(brand);
            IInfluencer currentInfluencer = influencers.FindByName(username);
            string campType = campain.GetType().Name;
            string infType = currentInfluencer.GetType().Name;

            if (campain.Contributors.Contains(username))
            {
                return $"{username} is already engaged for the {brand} campaign.";
            }

            if (campain.Budget <= 0 || campain.Budget < currentInfluencer.CalculateCampaignPrice())
            {
                return $"The budget for {brand} is insufficient to engage {username}.";
            }

            if (campType == "ProductCampaign" && infType == "BloggerInfluencer")
            // bussines + fashion
            {
                return $"{username} is not eligible for the {brand} campaign.";
            }

            if (campType == "ServiceCampaign" && infType == "FashionInfluencer")
            //bussines + bloggers
            {
                return $"{username} is not eligible for the {brand} campaign.";
            }

            currentInfluencer.EnrollCampaign(brand); //add participations to influencer

            campain.Engage(currentInfluencer); //namalq budjeta i dobavq influencera
            int cost = currentInfluencer.CalculateCampaignPrice();
            //double campBudget =campain.Budget;

            currentInfluencer.EarnFee((double)cost);

            return $"{username} has been successfully attracted to the {brand} campaign.";
        }

        public string BeginCampaign(string typeName, string brand)
        {
            // BeginCampaign ServiceCampaign FoodPanda

            if (typeName != "ProductCampaign" && typeName != "ServiceCampaign")
            {
                return $"{typeName} is not a valid campaign in the application.";
            }

            if (campaigns.Models.Any(c => c.Brand == brand))
            {
                return $"{brand} campaign cannot be duplicated.";
            }

            ICampaign campaign;
            if (typeName == "ProductCampaign")
            {
                campaign = new ProductCampaign(brand);
                campaigns.AddModel(campaign);
            }
            else if (typeName == "ServiceCampaign")
            {
                campaign = new ServiceCampaign(brand);
                campaigns.AddModel(campaign);
            }

            return $"{brand} started a {typeName}.";
        }

        public string CloseCampaign(string brand)
        {
            ICampaign campain = campaigns.FindByName(brand);
            if (campain == null)
            {
                return $"Trying to close an invalid campaign.";
            }

            if (campain.Budget <= 10000)
            {
                return $"{brand} campaign cannot be closed as it has not met its financial targets.";
            }
            if (campain.Budget > 10000)
            {
                foreach (string infName in campain.Contributors)
                {
                    IInfluencer currentInfluencer = influencers.FindByName(infName);
                    currentInfluencer.EarnFee(2000);
                }
            }

            foreach (string infName in campain.Contributors)
            {
                IInfluencer currentInfluencer = influencers.FindByName(infName);
                currentInfluencer.EndParticipation(brand);
            }

            campaigns.RemoveModel(campain);

            return $"{brand} campaign has reached its target.";
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer currentInfluencer = influencers.FindByName(username);
            if (currentInfluencer == null)
            {
                return $"{username} has still not signed a contract.";
            }


            if (currentInfluencer.Participations.Count == 0)
            {
                foreach (var campain in campaigns.Models)
                {
                    if (campain.Contributors.Contains(username))
                    {
                        return "{username} cannot conclude the contract while enrolled in active campaigns.";
                    }
                }
            }

            if (currentInfluencer.Participations.Count == 0)
            {
                influencers.RemoveModel(currentInfluencer);
            }


                return $"{username} concluded their contract.";
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign campain = campaigns.FindByName(brand);
            if (campain == null)
            {
                return $"Trying to fund an invalid campaign.";
            }

            if (amount <= 0)
            {
                return $"Funding amount must be greater than zero.";
            }

            campain.Gain(amount);

            return $"{brand} campaign has been successfully funded with {amount} $";
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            // RegisterInfluencer FashionInfluencer AlexFas_33 20000

            if (typeName != "BusinessInfluencer" && typeName != "FashionInfluencer" && typeName != "BloggerInfluencer")
            {
                return $"{typeName} has not passed validation.";
            }

            if (influencers.Models.Any(i => i.Username == username))
            {
                return $"{username} is already registered in {typeof(InfluencerRepository).Name}.";
            }

            IInfluencer influencer;

            if (typeName == "BusinessInfluencer")
            {
                //IInfluencer influencer = new BusinessInfluencer(username, followers);
                influencer = new BusinessInfluencer(username, followers);
                influencers.AddModel(influencer);
            }
            else if (typeName == "FashionInfluencer")
            {
                influencer = new FashionInfluencer(username, followers);
                influencers.AddModel(influencer);

            }
            else if (typeName == "BloggerInfluencer")
            {
                influencer = new BloggerInfluencer(username, followers);
                influencers.AddModel(influencer);

            }

            return $"{username} registered successfully to the application.";
        }
    }
}
