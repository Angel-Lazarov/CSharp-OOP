using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = new InfluencerRepository();
        }

        [Test]
        public void Constructor_CreatesRepository()
        {
            //InfluencerRepository repository = new InfluencerRepository();

            Assert.IsNotNull(repository);
        }

        [Test]

        public void RegisterInfluencer_Username()
        {
            Influencer influencer = new("Ivan", 5);
            repository.RegisterInfluencer(influencer);

            Assert.AreEqual(1, repository.Influencers.Count);

        }

        [Test]

        public void RegisterInfluencer_BadUsername_Ex()
        {
            Assert.Throws<ArgumentNullException>(() => repository.RegisterInfluencer(null));
        }

        [Test]

        public void RegisterInfluencer_NameExist_Ex()
        {
            Influencer influencer = new("Ivan", 5);
            repository.RegisterInfluencer(influencer);


            Assert.Throws<InvalidOperationException>(() => repository.RegisterInfluencer(influencer));
        }


        [Test]
        public void RegisterInfuleser_ok()
        {
            Influencer influencer = new("Ivan", 5);
            string result = repository.RegisterInfluencer(influencer);

            Assert.AreEqual(result, $"Successfully added influencer {influencer.Username} with {influencer.Followers}");

        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        public void RemoveInfluencer_IsNullOrWhiteSpace_Name_ex(string name)
        {
            Assert.Throws<ArgumentNullException>(() => repository.RemoveInfluencer(name));

        }

        [Test]
        public void RemoveInfluenser_Ok()
        {
            Influencer influencer = new("Ivan", 5);
            repository.RegisterInfluencer(influencer);

            var result = repository.RemoveInfluencer("Ivan");
            Assert.IsTrue(result);
        }

        [Test]
        public void GetInfluencerWithMostFollowers_Ok() 
        {
            Influencer influencer = new("Ivan", 5);
            Influencer influencer1 = new("Mimi", 1);
            repository.RegisterInfluencer(influencer);
            repository.RegisterInfluencer(influencer1);

            Influencer result =  repository.GetInfluencerWithMostFollowers();

            Assert.AreEqual(result, influencer);

        }

        [Test]
        public void GetInfluencer_OK() 
        {
            Influencer influencer = new("Ivan", 5);
            repository.RegisterInfluencer(influencer);

            Influencer result = repository.GetInfluencer("Ivan");

            Assert.AreEqual(influencer, result);
        }


    }




}
