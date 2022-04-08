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
        public string Password { get; set; }
        public virtual EmployeeMaster Employee { get; set; }
    }
}