using KatlaSport.Services.DepartmentManagement;

namespace KatlaSport.Services.EmployeeManagement
{
    public class EmployeeListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string ImagePath { get; set; }

        public Department Department { get; set; }
    }
}
