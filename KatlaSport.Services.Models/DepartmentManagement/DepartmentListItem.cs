namespace KatlaSport.Services.DepartmentManagement
{
    public class DepartmentListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Department[] ChildDepartments { get; set; } = new Department[] { };
    }
}
