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
    public class VenuesController : ControllerBase
    {
        private readonly VenueSL venueSL;

        public VenuesController(VenueSL venue)
        {
            venueSL = venue;
        }

        // GET: api/Venues
        [HttpGet]
        public ActionResult<IList<Venue>> GetVenues()
        {
            return venueSL.AllVenue().ToList();
        }

        // GET: api/Venues/5
        [HttpGet("{id}")]
        public ActionResult<Venue> GetVenue(int id)
        {
            var venue = venueSL.GetVenue(id);

            if (venue == null)
            {
                return NotFound();
            }

            return venue;
        }

        // PUT: api/Venues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutVenue(int id, Venue venue)
        {
            if (id != venue.ID)
            {
                return BadRequest();
            }
            else
            {
                if (venueSL.UpdateVenue(id, venue) == "Success")
                    return Ok();
                else
                    return BadRequest();
            }
        }

        // POST: api/Venues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Venue> PostVenue(Venue venue)
        {
            var result = venueSL.CreateVenue(venue);
            if (result == "Success")
                return Ok(venue);
            else
                return BadRequest();
        }

        // DELETE: api/Venues/5
        [HttpDelete("{id}")]
        public ActionResult DeleteVenue(int id)
        {
            var venue = venueSL.GetVenue(id);
            if (venue == null)
            {
                return NotFound();
            }
            else
            {
                venueSL.DeleteVenue(venue);
                return Ok();
            }
        }
    }
}
