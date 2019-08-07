using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.EmployeeDepartment;
using KatlaSport.Services.Exceptions;
using DbDepartment = KatlaSport.DataAccess.EmployeeDepartment.Department;

namespace KatlaSport.Services.DepartmentManagement
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentService"/> class with specified <see cref="IDepartmentContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IAwardContext"/>.</param>
        public DepartmentService(IDepartmentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<DepartmentListItem>> GetDepartmentsAsync()
        {
            var dbDepartments = await _context.Departments.Where(d => !d.IsDeleted && d.ParentId == null)
                .OrderBy(d => d.Id).ToArrayAsync();
            var parentDepartments = dbDepartments.Select(d => Mapper.Map<DepartmentListItem>(d)).ToList();
            foreach (var department in parentDepartments)
            {
                var dbChildDepartments = await _context.Departments.Where(d => !d.IsDeleted && d.ParentId == department.Id).ToArrayAsync();
                var childDepartments = dbChildDepartments.Select(d => Mapper.Map<Department>(d)).ToArray();
                department.ChildDepartments = childDepartments;
            }

            return parentDepartments;
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var dbDepartments = await _context.Departments.Where(d => d.Id == id && !d.IsDeleted)
               .OrderBy(d => d.Id).ToArrayAsync();
            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbDepartment = dbDepartments[0];
            var childDepartmentsCount = await _context.Departments.Where(d => d.ParentId == id).CountAsync();
            var employeesCount = await _context.Employees.Where(e => e.DepartmentId == id).CountAsync();
            if (childDepartmentsCount != 0)
            {
                throw new RequestedResourceHasConflictException($"Department still has child departments! {id}");
            }

            if (employeesCount == 0)
            {
                _context.Departments.Remove(dbDepartment);
            }
            else
            {
                dbDepartment.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<DepartmentSelectItem>> GetParentDepartmentsAsync()
        {
            var dbDepartments = await _context.Departments.Where(d => !d.IsDeleted && d.ParentId == null)
              .OrderBy(d => d.Id).ToArrayAsync();
            var parentDepartments = dbDepartments.Select(d => Mapper.Map<DepartmentSelectItem>(d)).ToList();
            return parentDepartments;
        }

        public async Task<List<DepartmentSelectItem>> GetChildDepartmentsAsync(int id)
        {
            var dbDepartments = await _context.Departments.Where(d => !d.IsDeleted && d.ParentId == id)
              .OrderBy(d => d.Id).ToArrayAsync();
            var parentDepartments = dbDepartments.Select(d => Mapper.Map<DepartmentSelectItem>(d)).ToList();
            return parentDepartments;
        }

        public async Task<Department> CreateDepartmentAsync(CreateDepartmentRequest createRequest)
        {
            var departmentId = createRequest.ParentId;
            if (departmentId != null)
            {
                var dbDepartments = await _context.Departments.Where(d => !d.IsDeleted && d.Id == departmentId).ToArrayAsync();
                if (dbDepartments.Length == 0)
                {
                    throw new RequestedResourceHasConflictException($"You can't add new department with not existing parent {nameof(departmentId)}");
                }
            }

            var dbDepartment = Mapper.Map<CreateDepartmentRequest, DbDepartment>(createRequest);
            _context.Departments.Add(dbDepartment);
            await _context.SaveChangesAsync();
            return Mapper.Map<Department>(dbDepartment);
        }

        public async Task<UpdateDepartmentData> GetDepartmentByIdAsync(int id)
        {
            var dbDepartments = await _context.Departments.Where(d => !d.IsDeleted && d.Id == id).ToArrayAsync();
            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbParentDepartments = await GetParentDepartmentsAsync();
            var parentDepartments = dbParentDepartments.Select(p => Mapper.Map<DepartmentSelectItem>(p)).ToArray();
            var requiredDepartment = Mapper.Map<UpdateDepartmentData>(dbDepartments[0]);
            requiredDepartment.ParentDepartments = parentDepartments;
            return requiredDepartment;
        }

        public async Task<Department> UpdateDepartmentAsync(int id, UpdateDepartmentRequest updateRequest)
        {
            var dbDepartments = await _context.Departments.Where(d => !d.IsDeleted && d.Id == id).ToArrayAsync();
            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbDepartment = dbDepartments[0];
            var parentDepartmentId = updateRequest.ParentId;
            if (parentDepartmentId != null)
            {
                var parentDepartments = await _context.Departments.Where(d => !d.IsDeleted
                    && d.ParentId == parentDepartmentId).ToArrayAsync();
                if (dbDepartments.Length == 0)
                {
                    throw new RequestedResourceHasConflictException($"You can't add new department with not existing parent {nameof(parentDepartmentId)}");
                }
            }

            Mapper.Map(updateRequest, dbDepartment);
            await _context.SaveChangesAsync();
            return Mapper.Map<Department>(dbDepartment);
        }
    }
}
