using KatlaSport.DataAccess.FirmEmployee;

namespace KatlaSport.DataAccess.EmployeeDepartment
{
    public interface IDepartmentContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Departments"/> entities.
        /// </summary>
        IEntitySet<Department> Departments { get; }

        IEntitySet<Employee> Employees { get; }
    }
}
