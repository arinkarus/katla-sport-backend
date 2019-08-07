using KatlaSport.Services.DepartmentManagement;

namespace KatlaSport.Services.EmployeeManagement
{
    public class EmployeeProfile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string About { get; set; }

        public string ImagePath { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }
    }
}
