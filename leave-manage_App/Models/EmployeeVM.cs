using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Models
{
    public class EmployeeVM
    {

        public int Id { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }

        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public int TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }

    }
}
