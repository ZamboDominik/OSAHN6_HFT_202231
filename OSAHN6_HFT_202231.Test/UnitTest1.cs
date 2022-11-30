using Moq;
using NUnit.Framework;
using OSAHN6_HFT_202231.Logic;
using OSAHN6_HFT_202231.Models;
using OSAHN6_HFT_202231.Repository;
using System.Collections.Generic;
using System.Linq;

namespace OSAHN6_HFT_202231.Test
{
    [TestFixture]
    public class Tests
    {
        TeamLogic teamLogic;
        Mock<IRepository<Team>> mockRepository;
        Team team;
        Player player;
        Coach hc;
        [SetUp]
        public void Init()
        {
            mockRepository = new Mock<IRepository<Team>>();
            player = new Player();
            player.Name = "bela";
            player.Salary = 1;
            player.TeamID = 1;
            player.Position = "takarito";
            hc = new Coach(); 
            hc.Salary = 1;
            hc.CoachId = 1;
            hc.CoachName = "bela2";
            hc.TeamID = 1;
            team = new Team();
            team.Players = new List<Player>();
            team.Id = 1;
            team.Name = "belaim";
            team.LuxuryTax = 0;
            hc.team = team;
            player.team = team;
            team.HeadCoach = hc;
            team.Players.Add(player);
            Team t2 = new Team() { Id = 2, Name = "Nembelak", LuxuryTax = 1 };
            Player p2 = new Player() { Name ="nembela",team = t2,TeamID = 2,PlayerId=2,Position="takarito",Salary=1};
            Coach hc2 = new Coach() { CoachName = "nembela2", team = t2, TeamID = 2, CoachId = 2, Salary = 1 };
            t2.HeadCoach = hc2;
            t2.Players = new List<Player>();
            t2.Players.Add(p2);
            List<Team> list =new List<Team> { team, t2 };
            mockRepository.Setup(t => t.ReadAll()).Returns(list.AsQueryable);
            teamLogic = new TeamLogic(mockRepository.Object);
        }

        [Test]
        public void StatTester()
        {
            PositionStats stats = new PositionStats() {Position ="takarito",AvgSalary=1,MaxSalary=1,MinSalary=1 };

            var actual = teamLogic.PositionStats();

            mockRepository.Verify(mock => mock.ReadAll(),Times.Once);
            Assert.That(actual,Has.Exactly(1).Items);
            
            foreach (var item in actual) 
            {
                Assert.That(item.MinSalary,Is.EqualTo(stats.MinSalary));
            }

        }
    }
}