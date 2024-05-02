using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Models
{
    public class LeaveTypeVM
    {

        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public DateTime? DateCreated { get; set; }

    }


}
