﻿using AutoMapper;
using DataAccessDepartment = KatlaSport.DataAccess.EmployeeDepartment.Department;

namespace KatlaSport.Services.DepartmentManagement
{
    internal sealed class DepartmentManagementMappingProfile : Profile
    {
        public DepartmentManagementMappingProfile()
        {
            CreateMap<DataAccessDepartment, DepartmentListItem>();
            CreateMap<DataAccessDepartment, Department>();
            CreateMap<DataAccessDepartment, DepartmentSelectItem>();
            CreateMap<CreateDepartmentRequest, DataAccessDepartment>();
            CreateMap<DataAccessDepartment, UpdateDepartmentData>();
            CreateMap<UpdateDepartmentRequest, DataAccessDepartment>();
        }
    }
}
