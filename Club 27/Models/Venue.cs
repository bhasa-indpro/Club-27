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
    public class Venue
    {
        [Key]
        public int VenueID { get; set; }

        [Required]
        public string VenueName { get; set; }

        public int? ActivityID { get; set; }
                
        [ForeignKey ("ActivityID")]
        public virtual ActivityMaster Activity { get; set; }
    }
}
