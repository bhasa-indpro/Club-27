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
        private readonly ILogger<BookingSL> _logger;

        public BookingSL(Club27DBContext context, ILogger<BookingSL> logger)
        {
            _context = context;
            _logger = logger;
        }



        public string CreateBooking(Booking booking)
        {
            try
            {
                if ((booking.Start < DateTime.Now) || (booking.End < DateTime.Now))
                {
                    return "You need a Time Machine mate";
                }

                TimeSpan startTime = booking.Start.TimeOfDay;
                TimeSpan endTime = booking.End.TimeOfDay;

                if (endTime < startTime)
                {
                    return "End time should be after Start Time";
                }

                int timeRangeFlag;

                TimeSpan openTime = new TimeSpan(7, 0, 0);
                TimeSpan closeTime = new TimeSpan(22, 0, 0);

                if ((startTime > openTime) && (endTime < closeTime))
                    timeRangeFlag = 1;
                else
                    timeRangeFlag = 0;

                if (timeRangeFlag == 0)
                    return "Please book during Venue operating hours (7 AM - 10 PM Only)";

                var currentBookingList = _context.Bookings.
                    Where(x => x.ActivityID == booking.ActivityID).
                    Where(y => y.VenueID == booking.VenueID).
                    ToList();

                int slotFlag = 1;
                foreach (var item in currentBookingList)
                {
                    TimeSpan itemStartTime = item.Start.TimeOfDay;
                    TimeSpan itemEndTime = item.End.TimeOfDay;

                    if ((startTime > itemStartTime) && (endTime < itemEndTime))
                    {
                        slotFlag = 0;
                        break;
                    }

                    if ((startTime < itemStartTime) && (endTime > itemEndTime))
                    {
                        slotFlag = 0;
                        break;
                    }

                    if ((startTime > itemStartTime) && (startTime < itemEndTime))
                    {
                        slotFlag = 0;
                        break;
                    }

                    if ((endTime > itemStartTime) && (endTime < itemEndTime))
                    {
                        slotFlag = 0;
                        break;
                    }
                }
                if (slotFlag == 0)
                    return "Slot Unavailable. Check slots in list properly.";

                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return "Success";


            }
            catch (DbUpdateException)
            {
                return "Error - Duplicate Booking";
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return "Failed Operation";
            }
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
                if ((booking.Start < DateTime.Now) || (booking.End < DateTime.Now))
                {
                    return "You need a Time Machine mate";
                }

                TimeSpan startTime = booking.Start.TimeOfDay;
                TimeSpan endTime = booking.End.TimeOfDay;

                if (endTime < startTime)
                {
                    return "End time should be after Start Time";
                }

                int timeRangeFlag;

                TimeSpan openTime = new TimeSpan(7, 0, 0);
                TimeSpan closeTime = new TimeSpan(22, 0, 0);

                if ((startTime > openTime) && (endTime < closeTime))
                    timeRangeFlag = 1;
                else
                    timeRangeFlag = 0;

                if (timeRangeFlag == 0)
                    return "Please book during Venue operating hours (7 AM - 10 PM Only)";

                var currentBookingList = _context.Bookings.
                    Where(x => x.ActivityID == booking.ActivityID).
                    Where(y => y.VenueID == booking.VenueID).
                    ToList();

                int slotFlag = 1;
                foreach (var item in currentBookingList)
                {
                    TimeSpan itemStartTime = item.Start.TimeOfDay;
                    TimeSpan itemEndTime = item.End.TimeOfDay;

                    if ((startTime > itemStartTime) && (endTime < itemEndTime))
                    {
                        slotFlag = 0;
                        break;
                    }

                    if ((startTime < itemStartTime) && (endTime > itemEndTime))
                    {
                        slotFlag = 0;
                        break;
                    }

                    if ((startTime > itemStartTime) && (startTime < itemEndTime))
                    {
                        slotFlag = 0;
                        break;
                    }

                    if ((endTime > itemStartTime) && (endTime < itemEndTime))
                    {
                        slotFlag = 0;
                        break;
                    }
                }
                if (slotFlag == 0)
                    return "Slot Unavailable. Check slots in list properly.";

                var currentBooking = GetBooking(id);

                currentBooking.ID = booking.ID;
                currentBooking.Start = booking.Start;
                currentBooking.End = booking.End;
                currentBooking.ActivityID = booking.ActivityID;
                currentBooking.VenueID = booking.VenueID;
                currentBooking.Fixture = booking.Fixture;
                _context.SaveChanges();
                return "Success";

            }
            catch (DbUpdateException)
            {
                return "Error - Duplicate Enrollment";
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return "Failed Operation";
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
