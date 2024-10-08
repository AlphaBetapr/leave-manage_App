﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using leave_manage_App.Data;

namespace leave_manage_App.Contracts
{
    public interface ILeaveRequestRepository : IRepositoryBase<LeaveHistories>
    {
        ICollection<LeaveHistories> GetLeaveRequestsByEmployee(String employeeid);
    }
}
