using AutoMapper;
using leave_manage_App.Data;
using leave_manage_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Mapping
{
    public class Maps : Profile
    {

        public Maps()
        {
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveHistory, LeaveHistoryVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
        }

    }
}
