using Microsoft.EntityFrameworkCore;
using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;

namespace OSAHN6_HFT_202231.Repository
{
    public class NBADbContext:DbContext
    {
        
        static List<Team> teamArray = new List<Team>
          {
            new Team(){ Id = 1,Name="Golden State Warriors",HeadCoach=null,LuxuryTax=50},
           // new Team(){ Id = 2,Name="Miami Heat",HeadCoach=null,LuxuryTax=0},
            new Team(){ Id = 2,Name="Dallas Maverics",HeadCoach=null,LuxuryTax=20},
            //new Team(){ Id = 4,Name="Memphis Grizzlies",HeadCoach=null,LuxuryTax=15},
          };
        static List<Coach> coachList = new List<Coach>
        {
            new Coach(){CoachId = 1, CoachName="Steve Kerr", team= teamArray[0], Salary = 5 },
            new Coach(){CoachId = 2, CoachName="Jason Kidd", team= teamArray[1], Salary = 2 },

        };
        static List<Player> playerList = new List<Player>()
         {
                new Player{ PlayerId = 1,Name = "Stephen Curry",team = teamArray[0], Position = "PG", Salary=33},
                new Player{ PlayerId = 2,Name = "Klay Thompson",team = teamArray[0], Position = "SG", Salary=20},
                new Player{ PlayerId = 3,Name = "Draymond Green",team = teamArray[0], Position = "PF", Salary=20},
                new Player{ PlayerId = 4,Name = "Kevon Looney",team = teamArray[0], Position = "C", Salary=5},
                new Player{ PlayerId = 5,Name = "Jordan Poole",team = teamArray[0], Position = "PG", Salary=20},
                new Player{ PlayerId = 6,Name = "Luka Doncic",team = teamArray[1], Position = "PG", Salary=30},
                new Player{ PlayerId = 7,Name = "Christion Wood",team = teamArray[1], Position = "PF", Salary=24},
                new Player{ PlayerId = 8,Name = "Spencer Dinwiddie",team = teamArray[1], Position = "SG", Salary=20},
                new Player{ PlayerId = 9,Name = "JaVale McGee",team = teamArray[1], Position = "C", Salary=7},
                new Player{ PlayerId = 10,Name = "Tim Hardaway",team = teamArray[1], Position = "SF", Salary=18},
         };
        DbSet<Team> Teams { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Coach> Coaches { get; set; }

        public NBADbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("NBADB").UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            teamArray[0].HeadCoach = coachList[0];
            teamArray[1].HeadCoach  = coachList[1];
            modelBuilder.Entity<Player>().HasOne(t => t.team).WithMany(t => t.Players).HasForeignKey(t => t.PlayerId);
            modelBuilder.Entity<Coach>().HasOne(t => t.team).WithOne(t => t.HeadCoach);
            modelBuilder.Entity<Player>().HasData(playerList);
            modelBuilder.Entity<Coach>().HasData(coachList);
            modelBuilder.Entity<Team>().HasData(teamArray);

            base.OnModelCreating(modelBuilder);
        }
    }

}
