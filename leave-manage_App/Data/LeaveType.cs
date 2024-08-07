using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Data
{
    public class LeaveType
    {
        [key]
         public int Id { get; set; }
        [required]
        public String Name { get; set; }
        public String DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
    }

}
