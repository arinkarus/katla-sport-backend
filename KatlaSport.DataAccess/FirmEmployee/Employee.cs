using KatlaSport.DataAccess.EmployeeAward;
using System.Collections.Generic;

namespace KatlaSport.DataAccess.FirmEmployee
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string About { get; set; }

        public virtual ICollection<Award> Awards { get; set; }
    }
}
