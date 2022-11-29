using Microsoft.AspNetCore.Mvc;
using OSAHN6_HFT_202231.Logic;
using OSAHN6_HFT_202231.Models;
using System.Collections.Generic;

namespace OSAHN6_HFT_202231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        IPlayerLogic logic;

        public PlayerController(IPlayerLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Player> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Player Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Player value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Player value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
