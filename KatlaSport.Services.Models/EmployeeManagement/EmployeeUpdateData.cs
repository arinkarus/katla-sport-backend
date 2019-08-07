namespace KatlaSport.Services.EmployeeManagement
{
    public class EmployeeUpdateData
    {
        public int ParentDepartmentId { get; set; }

        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string About { get; set; }
    }
}
