using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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



    }
}
