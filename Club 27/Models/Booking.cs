﻿using Microsoft.EntityFrameworkCore;
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
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int VenueID { get; set; }
        
        [ForeignKey ("VenueID")]
        public virtual Venue Venue { get; set; }

        public int ActivityID { get; set; }

        [ForeignKey ("ActivityID")]
        public virtual ActivityMaster Activity { get; set; }
        public string Fixture { get; set; }

        [NotMapped]
        public string[] ParticipantList { get; set; }
        
    }
}
