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
    public class VenueSL
    {
        private readonly Club27DBContext _context;

        public VenueSL(Club27DBContext context)
        {
            _context = context;
        }



        public string CreateVenue(Venue venue)
        {
            try
            {
                _context.Venues.Add(venue);
                _context.SaveChanges();
                return "Success";

            }
            catch (DbUpdateException)
            {
                return "Error - Venue already exists";
            }
        }

        public bool DeleteVenue(Venue venue)
        {
            var obj = _context.Venues.Where(x => x.ID == venue.ID).FirstOrDefault();
            if (obj != null)
            {
                _context.Venues.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string UpdateVenue(int id, Venue venue)
        {
            try
            {
                //var enr = _context.Enrollments.Where(x => x.EnrollmentID == employeeActivity.EnrollmentID)
                //            .Include(x => x.Employee).Include(x => x.Activity).Include(x => x.Venue).FirstOrDefault();
                //var count = _context.Enrollments.Where(x => x.EmployeeID == employeeActivity.EmployeeID).Count();
                var obj = GetVenue(id);

                obj.VenueName = venue.VenueName;
                obj.ActivityID = venue.ActivityID;

                _context.SaveChanges();
                return "Success";
            }
            catch (DbUpdateException)
            {
                return "Error - Venue already exists";
            }
        }

        public Venue GetVenue(int id)
        {
            try
            {
                var obj = _context.Venues.Where(x => x.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    return obj;
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

        public IList<Venue> AllVenue()
        {
            try
            {
                List<Venue> obj = _context.Venues.Include(x => x.Activity).ToList();
                if (obj != null)
                {
                    return obj;
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
