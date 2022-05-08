using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Club_27.Models;
using Microsoft.AspNetCore.Mvc;

namespace Club_27.Services
{
    public class BookingSL
    {
        private readonly Club27DBContext _context;

        public BookingSL(Club27DBContext context)
        {
            _context = context;
        }



        public bool CreateBooking(Booking booking)
        {
            try
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteBooking(Booking booking)
        {
            try
            {

                var emp = _context.Bookings.Where(x => x.ID == booking.ID).FirstOrDefault();
                if (emp != null)
                {
                    _context.Bookings.Remove(emp);
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

        public bool UpdateBooking(Booking booking)
        {
            try
            {
                var emp = _context.Bookings.Where(x => x.ID == booking.ID).FirstOrDefault();
                if (emp != null)
                {
                    //EmployeeMaster oldEmp = new EmployeeMaster();
                    //oldEmp.EmployeeID = employeeMaster.EmployeeID;
                    emp.BookedOn = booking.BookedOn;
                    emp.VenueID = booking.VenueID;
                    emp.ActivityID = booking.ActivityID;

                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public Booking GetBooking(int id)
        {
            try
            {
                var emp = _context.Bookings.Where(x => x.ID == id).FirstOrDefault();
                if (emp != null)
                {
                    return emp;
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
                List<Booking> emp = _context.Bookings.ToList();
                if (emp != null)
                {
                    return emp;
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
