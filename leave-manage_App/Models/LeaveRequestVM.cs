using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Models
{
    public class LeaveRequestVM
    {
        public int Id { get; set; }
        public EmployeeVM RequestingEmployee { get; set; }
        public String RequestingEmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public LeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }


        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }


        public EmployeeVM ApprovedBy { get; set; }
        public String ApprovedById { get; set; }

    }


    public class LeaveRequestEmployeeViewVM
    {
        
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }

    }

    public class LeaveRequestAdminViewVM
    {
        public int TotalRequest { get; set; }
        public int ApprovedRequest { get; set; }
        public int PendingRequest { get; set; }
        public int RejectedRequest { get; set; }

        public List<LeaveRequestVM> LeaveRequests { get; set; }

    }


    public class CreateLeaveRequestVM
    {

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; } 

    }



}
