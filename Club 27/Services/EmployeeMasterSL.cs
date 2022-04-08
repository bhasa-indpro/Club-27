using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Club_27.Models;
using Microsoft.AspNetCore.Mvc;

namespace Club_27.Services
{
    public class EmployeeMasterSL
    {
        private readonly Club27DBContext _context;

        public EmployeeMasterSL(Club27DBContext context)
        {
            _context = context;
        }

       

        public bool CreateEmployee(EmployeeMaster employeeMaster)
        {
            try
            {
                _context.EmployeeMasters.Add(employeeMaster);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteEmployee(EmployeeMaster employeeMaster)
        {
            try
            {

                var emp = _context.EmployeeMasters.Where(x => x.EmployeeID == employeeMaster.EmployeeID).FirstOrDefault();
                if (emp != null)
                {
                    _context.EmployeeMasters.Remove(emp);
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

        public bool UpdateEmployee(EmployeeMaster employeeMaster)
        {
            try
            {
                var emp = _context.EmployeeMasters.Where(x => x.EmployeeID == employeeMaster.EmployeeID).FirstOrDefault();
                if (emp != null)
                {
                    //EmployeeMaster oldEmp = new EmployeeMaster();
                    //oldEmp.EmployeeID = employeeMaster.EmployeeID;
                    emp.EmployeeName = employeeMaster.EmployeeName;
                    emp.Phone = employeeMaster.Phone;
                    emp.Email = employeeMaster.Email;

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

        public EmployeeMaster GetEmployee(int id)
        {
            try
            {
                var emp = _context.EmployeeMasters.Where(x => x.EmployeeID == id).FirstOrDefault();
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

        public IList<EmployeeMaster> AllEmployee()
        {
            try
            {
                List<EmployeeMaster> emp = _context.EmployeeMasters.ToList();
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
