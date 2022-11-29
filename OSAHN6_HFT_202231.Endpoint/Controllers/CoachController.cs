using Microsoft.AspNetCore.Mvc;
using OSAHN6_HFT_202231.Logic;
using OSAHN6_HFT_202231.Models;
using System.Collections.Generic;

namespace OSAHN6_HFT_202231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        ICoachLogic logic;

        public CoachController(ICoachLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Coach> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Coach Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Coach value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Coach value)
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
