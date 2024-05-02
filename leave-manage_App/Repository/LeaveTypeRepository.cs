using leave_manage_App.Contracts;
using leave_manage_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {

        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveType entity)
        {
            _db.leaveTypes.Add(entity);
            return save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.leaveTypes.Remove(entity);
            return save();
        }

        public ICollection<LeaveType> FindAll()
        {
            var LT = _db.leaveTypes.ToList();
            return LT;
        }

        public LeaveType FindById(int id)
        {
            var LT = _db.leaveTypes.Find(id);
            return LT;
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            var exists = _db.leaveTypes.Any(q => q.Id == id);
            return exists;
        }

        public bool save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveType entity)
        {
            _db.leaveTypes.Update(entity);
            return save();
        } 
    }
}
