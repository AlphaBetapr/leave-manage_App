using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using leave_manage_App.Data;

namespace leave_manage_App.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {

        bool CheckAllocation(int leavetypeid, string employeeid);
        ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(String id);

    }
}
