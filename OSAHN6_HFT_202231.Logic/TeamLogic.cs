using OSAHN6_HFT_202231.Models;
using OSAHN6_HFT_202231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSAHN6_HFT_202231.Logic
{
    public class TeamLogic:ITeamLogic
    {
        IRepository<Team> repo;

        public TeamLogic(IRepository<Team> repo)
        {
            this.repo = repo;
        }



        public void Create(Team item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Team Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Team> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Team item)
        {
            this.repo.Update(item);
        }
    }
}
