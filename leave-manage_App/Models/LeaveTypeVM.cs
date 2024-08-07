﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Models
{
    public class LeaveTypeVM
    {

        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Default Number Of Days")]
        [Range(1,25, ErrorMessage = "Please Enter A Valid Number")]
        public String DefaultDays { get; set; }

        [Display(Name="Date Created")]
        public DateTime? DateCreated { get; set; }

    }


}


