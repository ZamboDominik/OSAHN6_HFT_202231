using OSAHN6_HFT_202231.Logic;
using OSAHN6_HFT_202231.Models;
using OSAHN6_HFT_202231.Repository;
using System;
using System.Runtime.ConstrainedExecution;

namespace OSAHN6_HFT_202231
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NBADbContext NBA = new NBADbContext();
            TeamRepository team = new TeamRepository(NBA);
            TeamLogic tl = new TeamLogic(team);
            Console.WriteLine(tl.HighestSalary("Golden State Warriors"));
            /*RestService rest = new RestService("http://localhost:33531/", typeof(Team).Name);
            CrudService crud = new CrudService(rest);
            NonCrudService nonCrud = new NonCrudService(rest);

            var carSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Car>())
                .Add("Create", () => crud.Create<Car>())
                .Add("Delete", () => crud.Delete<Car>())
                .Add("Update", () => crud.Update<Car>())
                .Add("Exit", ConsoleMenu.Close);

            var brandSubMenu = new ConsoleMenu(args, level: 1)
                 .Add("List", () => crud.List<Brand>())
                 .Add("Create", () => crud.Create<Brand>())
                 .Add("Delete", () => crud.Delete<Brand>())
                 .Add("Update", () => crud.Update<Brand>())
                 .Add("Exit", ConsoleMenu.Close);

            var statsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Average car price", () => nonCrud.AvgCarPrice())
                .Add("Brand statistics", () => nonCrud.ReadBrandStats())
                .Add("Cars by Price range", () => nonCrud.GetCarsByPriceRange())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Cars", () => carSubMenu.Show())
                .Add("Brands", () => brandSubMenu.Show())
                .Add("Non-CRUD", () => statsSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();*/


            ;
        }
    }
}
