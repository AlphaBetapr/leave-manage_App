﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Data
{

   // LeaveHistories  ->  LeaveRequest

    public class LeaveHistories
    {
        [key]
        public int Id { get; set; }
        public Employee RequestingEmployee { get; set; }
        public String RequestingEmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }


        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }


        [ForeignKey("ApprovedById")]
        public Employee ApprovedBy { get; set; }
        public String ApprovedById { get; set; }

    }
}
