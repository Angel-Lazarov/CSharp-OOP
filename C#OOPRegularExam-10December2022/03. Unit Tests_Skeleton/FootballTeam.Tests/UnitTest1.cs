using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Xml.Linq;

namespace FootballTeam.Tests
{
    public class Tests
    {
        FootballTeam team;
        private List<FootballPlayer> Players;

        [SetUp]
        public void Setup()
        {
            team = new FootballTeam("name", 20);
        }

        [Test]
        public void Constructor_OK()
        {
            Assert.IsNotNull(team);
            Assert.AreEqual("name", team.Name);
            Assert.AreEqual(20, team.Capacity);
            Assert.AreEqual(0, team.Players.Count);

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]

        public void Constructor_Error_IsNullOrEmpty(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new FootballTeam(name, 20));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);

        }

        [Test]

        public void CapacitySize_Error()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new FootballTeam("name", 14));
            Assert.AreEqual("Capacity min value = 15", exception.Message);

        }

        [Test]
        [TestCase("Midfielder")]
        [TestCase("Goalkeeper")]
        [TestCase("Forward")]
        public void AddPlayer_OK_Midfielder(string position)
        {
            FootballPlayer player = new FootballPlayer("Ivan", 10, position);
            string actualReasult = team.AddNewPlayer(player);

            Assert.AreEqual(1, team.Players.Count);

            Assert.AreEqual($"Added player Ivan in position {player.Position} with number 10", actualReasult);
        }

        [Test]
        public void AddPlayer_WrongPosition_Error() 
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => team.AddNewPlayer(new FootballPlayer("Ivan", 10, "position")));
            Assert.AreEqual("Invalid Position", exception.Message);

        }

        [Test]

        public void AddPlayer_Error_NoFreeSpace()
        {
            team.Capacity = 16;
            for (int i = 0; i < 16; i++)
            {
                team.AddNewPlayer(new FootballPlayer("Ivan", 10, "Forward"));
            }

            Assert.AreEqual("No more positions available!", team.AddNewPlayer(new FootballPlayer("Ivan", 10, "Forward")));


        }


        [Test]
        public void PickPlayer_OK()
        {

            FootballPlayer playerIvan = new FootballPlayer("Ivan", 10, "Forward");
            team.AddNewPlayer(playerIvan);

            Assert.AreEqual(team.PickPlayer("Ivan"), playerIvan);
            Assert.AreEqual(team.PickPlayer("Mima"), null);

        }

        [Test]
        public void PlayerScore_ok()
        {
            FootballPlayer player = new FootballPlayer("Ivan", 10, "Forward");
            team.AddNewPlayer(player);
            string expected = team.PlayerScore(player.PlayerNumber);


            Assert.AreEqual(1, player.ScoredGoals);
            Assert.AreEqual($"Ivan scored and now has 1 for this season!", expected);

        }

        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void PlayerWrongName(string name)
        {

            ArgumentException exception = Assert.Throws<ArgumentException>(() => new FootballPlayer(name, 10, "Forward"));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);

        }

        [Test]
        [TestCase(0)]
        [TestCase(22)]
        public void PlayerNumber_NotOK(int number)
        {

            ArgumentException exception = Assert.Throws<ArgumentException>(() => new FootballPlayer("name", number, "Forward"));
            Assert.AreEqual("Player number must be in range [1,21]", exception.Message);

        }
    }
}