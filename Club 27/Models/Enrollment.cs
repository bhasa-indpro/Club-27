using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club_27.Models
{
    //[Table ("Enrollment")]
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        public int EmployeeID { get; set; }
        public int ActivityID { get; set; }
                
        [ForeignKey ("EmployeeID")]
        public virtual EmployeeMaster Employee { get; set; }

        [ForeignKey ("ActivityID")]
        public virtual ActivityMaster Activity { get; set; }

        public int? TeamID { get; set; }

        [ForeignKey ("TeamID")]
        public virtual Team Team { get; set; }
    }
}
