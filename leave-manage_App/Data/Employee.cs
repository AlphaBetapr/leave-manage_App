using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Data
{
    public class Employee : IdentityUser
    {

        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public int TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }

    }
}
