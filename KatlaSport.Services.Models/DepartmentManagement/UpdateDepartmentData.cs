namespace KatlaSport.Services.DepartmentManagement
{
    public class UpdateDepartmentData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public DepartmentSelectItem[] ParentDepartments { get; set; } = new DepartmentSelectItem[] { };
    }
}
