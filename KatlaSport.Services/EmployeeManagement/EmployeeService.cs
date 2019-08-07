using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.FirmEmployee;
using KatlaSport.Services.DepartmentManagement;
using KatlaSport.Services.Exceptions;
using KatlaSport.Services.ImageManagement;
using DbEmployee = KatlaSport.DataAccess.FirmEmployee.Employee;

namespace KatlaSport.Services.EmployeeManagement
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeContext _context;

        public EmployeeService(IEmployeeContext context)
        {
            _context = context;
        }

        public async Task<EmployeeProfile> GetEmployeeProfileById(int id)
        {
            var dbEmployee = await GetEmployeeIfExistsAsync(id);
            var employee = Mapper.Map<EmployeeProfile>(dbEmployee);
            return employee;
        }

        public async Task<Employee> CreateEmployeeAsync(UpdateEmployeeRequest createRequest)
        {
            var departments = await _context.Departments.Where(s => !s.IsDeleted && s.Id == createRequest.DepartmentId).ToArrayAsync();
            if (departments.Length == 0)
            {
                throw new RequestedResourceHasConflictException();
            }

            var dbEmployee = Mapper.Map<DbEmployee>(createRequest);
            _context.Employees.Add(dbEmployee);
            await _context.SaveChangesAsync();
            return Mapper.Map<Employee>(dbEmployee);
        }

        public async Task<List<EmployeeListItem>> GetEmployeesAsync()
        {
            var dbEmployees = await _context.Employees.OrderBy(a => a.Id).IncludeMultiple(a => a.Department).ToArrayAsync();
            return dbEmployees.Select(a => Mapper.Map<EmployeeListItem>(a)).ToList();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var dbEmployee = await GetEmployeeIfExistsAsync(id);
            _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(int id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var dbEmployee = await GetEmployeeIfExistsAsync(id);
            Mapper.Map(updateEmployeeRequest, dbEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<UpdateEmployeeData> GetEmployeeAsync(int id)
        {
            var dbEmployee = await GetEmployeeIfExistsAsync(id);
            var dbParentDepartments = await _context.Departments.Where(d => d.ParentId == null && !d.IsDeleted).ToArrayAsync();
            var parentDepartments = dbParentDepartments.Select(s => Mapper.Map<DepartmentSelectItem>(s)).ToArray();

            var employeeDepartments = await _context.Departments.Where(d => d.Id == dbEmployee.DepartmentId).ToArrayAsync();
            var parentDepartmentId = employeeDepartments[0].ParentId;

            var dbChildDepartments = await _context.Departments.Where(d => d.ParentId == parentDepartmentId && !d.IsDeleted).ToArrayAsync();
            var childDepartments = dbChildDepartments.Select(s => Mapper.Map<DepartmentSelectItem>(s)).ToArray();

            var updateEmployeeData = Mapper.Map<UpdateEmployeeData>(dbEmployee);
            updateEmployeeData.ChildDepartments = childDepartments;
            updateEmployeeData.ParentDepartments = parentDepartments;
            updateEmployeeData.Employee = Mapper.Map<EmployeeUpdateData>(dbEmployee);
            updateEmployeeData.Employee.ParentDepartmentId = (int)parentDepartmentId;
            return updateEmployeeData;
        }

        public async Task<ImageResult> UpdateEmployeePhotoAsync(int id, ImageData imageData, IImageService imageService)
        {
            var dbEmployee = await GetEmployeeIfExistsAsync(id);
            var imageResult = await imageService.AddAsync(imageData, dbEmployee.ImagePath);
            dbEmployee.ImagePath = imageResult.NewPath;
            await _context.SaveChangesAsync();
            return imageResult;
        }

        public async Task DeleteEmployeePhotoAsync(int id, IImageService imageService)
        {
            var dbEmployee = await GetEmployeeIfExistsAsync(id);
            await imageService.DeleteAsync(dbEmployee.ImagePath);
            dbEmployee.ImagePath = null;
            await _context.SaveChangesAsync();
        }

        private async Task<DbEmployee> GetEmployeeIfExistsAsync(int id)
        {
            var dbEmployees = await _context.Employees.Where(s => s.Id == id).IncludeMultiple(a => a.Department).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return dbEmployees[0];
        }
    }
}
