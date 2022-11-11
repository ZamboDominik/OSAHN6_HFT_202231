using Microsoft.EntityFrameworkCore;
using OSAHN6_HFT_202231.Models;
using System;

namespace OSAHN6_HFT_202231.Repository
{
    public class NBADbContext:DbContext
    {
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
            modelBuilder.Entity<Player>().HasOne(t => t.team).WithMany(t => t.Players).HasForeignKey(t => t.PlayerId);
            modelBuilder.Entity<Coach>().HasOne(t => t.team).WithOne(t => t.HeadCoach);
            var teamArray = new Team[]
            {
            new Team(){ Id = 1,Name="Golden State Warriors",HeadCoach=null,LuxuryTax=50},
            };
            var playerArray = new Player[]
            {
                new Player{ PlayerId = 1,Name = "Stephen Curry",team = teamArray[0], Position = "PG", Salary=30},
                 new Player{ PlayerId = 2,Name = "Klay Thompson",team = teamArray[0], Position = "SG", Salary=20},
                  new Player{ PlayerId = 3,Name = "Draymond Green",team = teamArray[0], Position = "PF", Salary=20},
                   new Player{ PlayerId = 4,Name = "Kevon Looney",team = teamArray[0], Position = "C", Salary=5},
                    new Player{ PlayerId = 5,Name = "Jordan Poole",team = teamArray[0], Position = "PG", Salary=20},
            };
            base.OnModelCreating(modelBuilder);
        }
    }

}
