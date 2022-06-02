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
    public class BookingsController : ControllerBase
    {
        private readonly BookingSL bookingSL;

        public BookingsController(BookingSL booking)
        {
            bookingSL = booking;
        }

        // GET: api/Bookings
        [HttpGet]
        public ActionResult<IList<Booking>> GetBookings()
        {
            return bookingSL.AllBooking().ToList();
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public ActionResult<Booking> GetBooking(int id)
        {
            var booking = bookingSL.GetBooking(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutBooking(int id, Booking booking)
        {
            if (id != booking.ID)
            {
                return BadRequest();
            }
            else
            {
                if (bookingSL.UpdateBooking(id, booking) == "Success")
                    return Ok();
                else
                    return BadRequest();
            }
        }

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Booking> PostBooking(Booking booking)
        {
            var result = bookingSL.CreateBooking(booking);
            if (result == "Success")
                return Ok(booking);
            else
                return BadRequest();
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(int id)
        {
            var booking = bookingSL.GetBooking(id);
            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                bookingSL.DeleteBooking(booking);
                return Ok();
            }
        }
    }
}
