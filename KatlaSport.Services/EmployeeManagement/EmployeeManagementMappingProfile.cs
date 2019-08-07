namespace KatlaSport.Services.EmployeeManagement
{
    using AutoMapper;
    using DataAccessEmployee = KatlaSport.DataAccess.FirmEmployee.Employee;

    internal class EmployeeManagementMappingProfile : Profile
    {
        public EmployeeManagementMappingProfile()
        {
            CreateMap<DataAccessEmployee, UpdateEmployeeData>();
            CreateMap<DataAccessEmployee, Employee>();
            CreateMap<DataAccessEmployee, EmployeeListItem>();
            CreateMap<DataAccessEmployee, EmployeeUpdateData>();
            CreateMap<DataAccessEmployee, EmployeeProfile>();
            CreateMap<UpdateEmployeeData, DataAccessEmployee>();
            CreateMap<UpdateEmployeeRequest, DataAccessEmployee>();
        }
    }
}
