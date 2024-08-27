using leave_manage_App.Contracts;
using leave_manage_App.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool isExists(int id)
        {
            var exists = _db.leaveAllocations.Any(q => q.Id == id);
            return exists;
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.leaveAllocations.Add(entity);
            return save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.leaveAllocations.Remove(entity);
            return save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var LA = _db.leaveAllocations.Include(q => q.LeaveType).Include(q => q.Employee).ToList();
            return LA;
        }

        public LeaveAllocation FindById(int id)
        {
            var LA = _db.leaveAllocations.Include(q => q.LeaveType).Include(q => q.Employee).FirstOrDefault(q => q.Id == id);
            return LA;
        }

        public bool save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.leaveAllocations.Update(entity);
            return save();
        }

        public bool CheckAllocation(int leavetypeid, string employeeid)
        {
            var period = DateTime.Now.Year;

            return FindAll().Where(q => q.EmployeeId == employeeid && q.LeaveTypeId == leavetypeid && q.Period == period).Any();

        }

        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string employeeid)
        {

            var period = DateTime.Now.Year;
            return FindAll().Where(q => q.EmployeeId == employeeid && q.Period == period).ToList(); 

        }

        public LeaveAllocation GetLeaveAllocationsByEmployeeAndType(string employeeid, int LeaveTypeid)
        {
            var period = DateTime.Now.Year;
            return FindAll().FirstOrDefault(q => q.EmployeeId == employeeid && q.Period == period && q.LeaveTypeId == LeaveTypeid);
        }
    }
}
