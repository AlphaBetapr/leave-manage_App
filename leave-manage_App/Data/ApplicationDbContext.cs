using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using leave_manage_App.Models;

namespace leave_manage_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveType> leaveTypes { get; set; }
        public DbSet<LeaveHistory> leaveHistories { get; set; }
        public DbSet<LeaveAllocation> leaveAllocations { get; set; }
        public DbSet<LeaveTypeVM> LeaveTypeVM { get; set; }
        public DbSet<leave_manage_App.Models.LeaveAllocationVM> LeaveAllocationVM { get; set; }
        public DbSet<leave_manage_App.Models.EditLeaveAllocationVM> EditLeaveAllocationVM { get; set; }


    }
}
