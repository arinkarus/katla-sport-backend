﻿using KatlaSport.Services.DepartmentManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/departments")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class DepartmentsController : ApiController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of departments.",
            Type = typeof(DepartmentSelectItem[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetDepartments()
        {
            var departments = await _departmentService.GetDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet]
        [Route("parents")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of parent departments.",
            Type = typeof(DepartmentSelectItem[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetParentDepartments()
        {
            var departments = await _departmentService.GetParentDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet]
        [Route("parents/{parentId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of child departments.",
         Type = typeof(DepartmentSelectItem[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetParentDepartments(int parentId)
        {
            var departments = await _departmentService.GetChildDepartmentsAsync(parentId);
            return Ok(departments);
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed department.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteDepartment([FromUri] int id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new department.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddDepartment([FromBody]CreateDepartmentRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdDepartment = await _departmentService.CreateDepartmentAsync(createRequest);
            var location = string.Format("/api/departments/{0}", createdDepartment.Id);
            return Created<Department>(location, createdDepartment);
        }

        [HttpGet]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a department.", 
            Type = typeof(UpdateDepartmentData))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetDepartment(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            return Ok(department);
        }

        [HttpPut]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent,
            Description = "Updates an existed department.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateDepartment([FromUri] int id, [FromBody] UpdateDepartmentRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _departmentService.UpdateDepartmentAsync(id, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}