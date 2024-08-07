using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Data
{
    public class LeaveAllocation
    {
        [key]
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }


        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public String EmployeeId { get; set; }


        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }


        public int Period { get; set; }

    }
}
