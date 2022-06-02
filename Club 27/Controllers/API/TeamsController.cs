using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Club_27.Models;
using Club_27.Services;

namespace Club_27.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamSL teamSL;

        public TeamsController(TeamSL team)
        {
            teamSL = team;
        }

        // GET: api/Teams
        [HttpGet]
        public ActionResult<IList<Team>> GetTeams()
        {
            return teamSL.AllTeam().ToList();
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public ActionResult<Team> GetTeam(int id)
        {
            var team = teamSL.GetTeam(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutTeam(int id, Team team)
        {
            if (id != team.ID)
            {
                return BadRequest();
            }
            else
            {
                if (teamSL.UpdateTeam(id, team) == "Success")
                    return Ok();
                else
                    return BadRequest();
            }
        }

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Team> PostTeam(Team team)
        {
            var result = teamSL.CreateTeam(team);
            if (result == "Success")
                return Ok(team);
            else
                return BadRequest();
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTeam(int id)
        {
            var team = teamSL.GetTeam(id);
            if (team == null)
            {
                return NotFound();
            }
            else
            {
                teamSL.DeleteTeam(team);
                return Ok();
            }
        }
    }
}
