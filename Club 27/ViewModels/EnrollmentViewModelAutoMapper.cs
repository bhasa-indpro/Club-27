﻿using Club_27.Models;

namespace Club_27.ViewModels
{
    public class EnrollmentViewModelAutoMapper
    {
        public string EmployeeName { get; set; }
        public string ActivityName { get; set; }

        public List<string> ActivityNameList { get; set; }
        //public virtual EmployeeMaster Employee { get; set; }
        //public virtual ActivityMaster ActivityMaster { get; set; }
    }
}