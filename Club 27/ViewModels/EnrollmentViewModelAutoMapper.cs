using Club_27.Models;

namespace Club_27.ViewModels
{
    public class EnrollmentViewModelAutoMapper
    {
        public string EmployeeName { get; set; }
        public string ActivityName { get; set; }
        public List<string> ActivityNameList { get; set; }
        public int ActivityCount { get; set; }
        public List<ActivityFlag> ActivityFlagList { get; set; }
        //public virtual EmployeeMaster Employee { get; set; }
        //public virtual ActivityMaster ActivityMaster { get; set; }
    }

    public class ActivityFlag
    {
        public string ActName { get; set; }
        public int FlagValue { get; set; }
    }
}
