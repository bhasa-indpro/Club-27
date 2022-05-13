using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Club_27.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Club_27.Services
{
    public class BookingSL
    {
        private readonly Club27DBContext _context;

        public BookingSL(Club27DBContext context)
        {
            _context = context;
        }



        public string CreateBooking(Booking booking)
        {
            //var count = _context.Enrollments.Where(x => x.EmployeeID == employeeActivity.EmployeeID).Count();
            //var teamMaxCount = _context.Enrollments.Where(x => x.TeamID == employeeActivity.TeamID)
            //                    .Where(x => x.ActivityID == employeeActivity.ActivityID).Count();

            //var currentTeam = _context.Teams.Where(x => x.ID == employeeActivity.TeamID)
            //                    .Where(x => x.ActivityID == employeeActivity.ActivityID).FirstOrDefault();
            //if (teamMaxCount < currentTeam.MaxLimit)
            //{
            //    if (count < 4)
            //    {
                    try
                    {
                        _context.Bookings.Add(booking);
                        _context.SaveChanges();
                        return "Success";

                    }
                    catch (DbUpdateException)
                    {
                        return "Error - Duplicate Booking";
                    }
            //    }
            //    else
            //        return "Error - Maximum of 4 activities only";
            //}
            //else
            //{
            //    return "Error - Team already full";
            //}

        }

        public bool DeleteBooking(Booking booking)
        {
            try
            {
                var currentBooking = _context.Bookings.Where(x => x.ID == booking.ID).FirstOrDefault();
                if (currentBooking != null)
                {
                    _context.Bookings.Remove(currentBooking);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string UpdateBooking(int id, Booking booking)
        {
            try
            {
                //var enr = _context.Enrollments.Where(x => x.EnrollmentID == employeeActivity.EnrollmentID)
                //            .Include(x => x.Employee).Include(x => x.Activity).Include(x => x.Team).FirstOrDefault();
                //var count = _context.Enrollments.Where(x => x.EmployeeID == employeeActivity.EmployeeID).Count();

                //var teamMaxCount = _context.Enrollments.Where(x => x.TeamID == employeeActivity.TeamID)
                //                .Where(x => x.ActivityID == employeeActivity.ActivityID).Count();

                //var currentTeam = _context.Teams.Where(x => x.ID == employeeActivity.TeamID)
                //                    .Where(x => x.ActivityID == employeeActivity.ActivityID).FirstOrDefault();

                //if (teamMaxCount < currentTeam.MaxLimit)
                //{
                    var currentBooking = GetBooking(id);

                    currentBooking.ID = booking.ID;
                    currentBooking.BookedOn = booking.BookedOn;
                    currentBooking.ActivityID = booking.ActivityID;
                    currentBooking.VenueID = booking.VenueID;
                    currentBooking.Fixture = booking.Fixture;

                    _context.SaveChanges();
                    return "Success";
                //}
                //else
                //    return "Error - Team already full";
            }
            catch (DbUpdateException)
            {
                return "Error - Duplicate Enrollment";
            }
        }

        public Booking GetBooking(int id)
        {
            try
            {
                var bookingItem = _context.Bookings.Where(x => x.ID == id).FirstOrDefault();
                if (bookingItem != null)
                {
                    return bookingItem;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList<Booking> AllBooking()
        {
            try
            {
                List<Booking> bookingList = _context.Bookings.Include(x => x.Activity).Include(x => x.Venue).ToList();
                if (bookingList != null)
                {
                    return bookingList;
                }
                else
                {

                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
