using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using beerpong_api.Services;
using beerpong_api.Models;

namespace beerpong_api.Controllers
{
    [Route("api/[controller]")]
    public class TournamentController : Controller
    {
        public readonly IDbService _DbService;

        public TournamentController(IDbService DbService)
        {
            _DbService = DbService;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<Tournament> GetTournament(int id)
        {
            return _DbService.GetTournamentByIdAsync(id);
        }

        [HttpGet("last")]
        public Tournament GetLastTournament()
        {
            return _DbService.GetLastTournament();
        }

        [HttpGet("pool/{id}")]
        public Pool GetPoolById(int id)
        {
            return _DbService.GetPoolById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Tournament tournament)
        {
            _DbService.CreateTournament(tournament);
        }

        // PUT api/values/5
        [HttpPut("match/{id}")]
        public void Put(int id, [FromBody]Match match)
        {
            _DbService.UpdateMatch(id, match);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
