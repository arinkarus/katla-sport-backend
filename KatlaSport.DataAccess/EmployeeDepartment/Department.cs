namespace KatlaSport.DataAccess.EmployeeDepartment
{
    public class Department
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public Department ParentDepartment { get; set; }

        public bool IsDeleted { get; set; }
    }
}
