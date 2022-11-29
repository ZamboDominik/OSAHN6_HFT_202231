using Microsoft.AspNetCore.Mvc;
using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSAHN6_HFT_202231.Client
{
    internal class NonCrudService
    {
        private RestService rest;

        public NonCrudService(RestService rest)
        {
            this.rest = rest;
        }
        public void StarPlayers()
        {
            var items = rest.Get<Player>($"Stat/StarPlayers");
            foreach (var item in items) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
