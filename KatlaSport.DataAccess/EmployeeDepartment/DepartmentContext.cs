﻿using KatlaSport.DataAccess.FirmEmployee;

namespace KatlaSport.DataAccess.EmployeeDepartment
{
    internal class DepartmentContext : DomainContextBase<ApplicationDbContext>, IDepartmentContext
    {
        public DepartmentContext(ApplicationDbContext dbContext)
       : base(dbContext)
        {
        }

        public IEntitySet<Department> Departments => GetDbSet<Department>();

        public IEntitySet<Employee> Employees => GetDbSet<Employee>();
    }
}
