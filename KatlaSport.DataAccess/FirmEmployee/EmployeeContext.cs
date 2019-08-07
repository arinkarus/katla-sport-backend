using KatlaSport.DataAccess.EmployeeDepartment;

namespace KatlaSport.DataAccess.FirmEmployee
{
    internal class EmployeeContext : DomainContextBase<ApplicationDbContext>, IEmployeeContext
    {
        public EmployeeContext(ApplicationDbContext dbContext)
          : base(dbContext)
        {
        }

        public IEntitySet<Employee> Employees => GetDbSet<Employee>();

        public IEntitySet<Department> Departments => GetDbSet<Department>();
    }
}
