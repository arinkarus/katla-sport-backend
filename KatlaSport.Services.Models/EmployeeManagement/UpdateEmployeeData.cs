using KatlaSport.Services.DepartmentManagement;

namespace KatlaSport.Services.EmployeeManagement
{
    public class UpdateEmployeeData
    {
        public DepartmentSelectItem[] ParentDepartments { get; set; }

        public DepartmentSelectItem[] ChildDepartments { get; set; }

        public EmployeeUpdateData Employee { get; set; }
    }
}
