using leave_manage_App.Contracts;
using leave_manage_App.Data;
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
            var LA = _db.leaveAllocations.ToList();
            return LA;
        }

        public LeaveAllocation FindById(int id)
        {
            var LA = _db.leaveAllocations.Find(id);
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
    }
}
