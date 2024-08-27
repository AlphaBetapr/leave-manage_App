using leave_manage_App.Contracts;
using leave_manage_App.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {


        private readonly ApplicationDbContext _db;

        public LeaveRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveHistories entity)
        {
            _db.leaveHistories.Add(entity);
            return save();
        }

        public bool Delete(LeaveHistories entity)
        {
            _db.leaveHistories.Remove(entity);
            return save();
        }

        public ICollection<LeaveHistories> FindAll()
        {
            var LH = _db.leaveHistories.Include(q => q.RequestingEmployee).Include(q => q.ApprovedBy).Include(q => q.LeaveType).ToList();
            return LH;
        }

        public LeaveHistories FindById(int id)
        {
            var LH = _db.leaveHistories.Include(q => q.RequestingEmployee).Include(q => q.ApprovedBy).Include(q => q.LeaveType).FirstOrDefault(q => q.Id == id);
            return LH;
        }

        public ICollection<LeaveHistories> GetLeaveRequestsByEmployee(string employeeid)
        {
            // return FindAll().Where(q => q.EmployeeId == employeeid && q.Period == period).ToList();
            return FindAll().Where(q => q.RequestingEmployeeId == employeeid).ToList();
        }

        public bool isExists(int id)
        {
            var exists = _db.leaveHistories.Any(q => q.Id == id);
            return exists;
        }

        public bool save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveHistories entity)
        {
            _db.leaveHistories.Update(entity);
            return save();
        }
    }
}
