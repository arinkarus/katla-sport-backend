using FluentValidation.Attributes;

namespace KatlaSport.Services.EmployeeManagement
{
    [Validator(typeof(UpdateEmployeeRequestValidator))]
    public class UpdateEmployeeRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string About { get; set; }

        public int DepartmentId { get; set; }
    }
}
