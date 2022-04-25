using Club_27.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Club27.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [ForeignKey("EmployeeID")]
        public virtual EmployeeMaster Employee { get; set; }

        public int RoleID { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }
    }
}