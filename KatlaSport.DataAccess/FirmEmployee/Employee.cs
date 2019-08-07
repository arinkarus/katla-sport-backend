using System.Collections.Generic;
using KatlaSport.DataAccess.EmployeeAward;
using KatlaSport.DataAccess.EmployeeDepartment;

namespace KatlaSport.DataAccess.FirmEmployee
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string About { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<AwardEmployee> AwardsForEmployees { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
