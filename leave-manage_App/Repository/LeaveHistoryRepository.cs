using leave_manage_App.Contracts;
using leave_manage_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {


        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveHistory entity)
        {
            _db.leaveHistories.Add(entity);
            return save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.leaveHistories.Remove(entity);
            return save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var LH = _db.leaveHistories.ToList();
            return LH;
        }

        public LeaveHistory FindById(int id)
        {
            var LH = _db.leaveHistories.Find(id);
            return LH;
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

        public bool Update(LeaveHistory entity)
        {
            _db.leaveHistories.Update(entity);
            return save();
        }
    }
}
