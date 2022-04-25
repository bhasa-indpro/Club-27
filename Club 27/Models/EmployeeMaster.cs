using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club_27.Models
{
    public class EmployeeMaster
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid E-Mail Address")]
        public string Email { get; set; }

        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public long Phone { get; set; }

        public int RoleID { get; set; }

        [ForeignKey ("RoleID")]
        public virtual Role Role { get; set; }
    }
}
