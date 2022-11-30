using Microsoft.AspNetCore.Mvc;
using OSAHN6_HFT_202231.Logic;
using OSAHN6_HFT_202231.Models;
using System.Collections.Generic;
using System.Linq;

namespace OSAHN6_HFT_202231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        ITeamLogic logic;

        public TeamController(ITeamLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Team> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Team Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Team value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromQuery] Team value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
        /*[HttpGet]
        public void StarPlayers() 
        {
            this.logic.StarPlayers();
        }
        [HttpGet]
        public void PositionStats() { this.logic.PositionStats(); }
        [HttpGet("{name}")]
        public void ListPlayersCoachedBy(string name) { this.ListPlayersCoachedBy(name); }
        [HttpGet("{team}/{Pos}")]
        public void PlayerListByPos(string team, string Pos) { this.logic.PlayerListByPos(team, Pos); }
        [HttpGet("{team}")]
        public void HighestSalary(string team) { this.logic.HighestSalary(team); }*/
    }
}
