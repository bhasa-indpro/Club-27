using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club_27.Models
{
    public class ActivityMaster
    {
        [Key]
        public int ActivityID { get; set; }
        [Required]
        public string ActivityName { get; set; }
    }
}
