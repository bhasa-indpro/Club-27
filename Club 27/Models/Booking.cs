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
    public class Booking
    {
        [Key]
        public int ID { get; set; }
                
        public DateTime BookedOn { get; set; }
        public int VenueID { get; set; }
        
        [ForeignKey ("VenueID")]
        public virtual Venue Venue { get; set; }

        public int ActivityID { get; set; }

        [ForeignKey ("ActvityID")]
        public virtual ActivityMaster Activity { get; set; }
        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual EmployeeMaster Employee { get; set; }
    }
}
