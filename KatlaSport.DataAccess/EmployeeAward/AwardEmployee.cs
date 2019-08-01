using KatlaSport.DataAccess.FirmEmployee;

namespace KatlaSport.DataAccess.EmployeeAward
{
    public class AwardEmployee
    {
        public int AwardId { get; set; }

        public int EmployeeId { get; set; }

        public Award Award { get; set; }

        public Employee Employee { get; set; }
    }
}
