using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Club_27.Models;
using Microsoft.AspNetCore.Mvc;

namespace Club_27.Services
{
    public class VenueSL
    {
        private readonly Club27DBContext _context;

        public VenueSL(Club27DBContext context)
        {
            _context = context;
        }



        public bool CreateVenue(Venue venue)
        {
            try
            {
                _context.Venues.Add(venue);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteVenue(Venue venue)
        {
            try
            {

                var emp = _context.Venues.Where(x => x.ID == venue.ID).FirstOrDefault();
                if (emp != null)
                {
                    _context.Venues.Remove(emp);
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

        public bool UpdateVenue(Venue venue)
        {
            try
            {
                var emp = _context.Venues.Where(x => x.ID == venue.ID).FirstOrDefault();
                if (emp != null)
                {
                    //EmployeeMaster oldEmp = new EmployeeMaster();
                    //oldEmp.EmployeeID = employeeMaster.EmployeeID;
                    emp.VenueName = venue.VenueName;
                    emp.ActivityID = venue.ActivityID;

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

        public Venue GetVenue(int id)
        {
            try
            {
                var emp = _context.Venues.Where(x => x.ID == id).FirstOrDefault();
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

        public IList<Venue> AllVenue()
        {
            try
            {
                List<Venue> emp = _context.Venues.ToList();
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
