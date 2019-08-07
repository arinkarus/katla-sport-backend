using FluentValidation.Attributes;

namespace KatlaSport.Services.DepartmentManagement
{
    [Validator(typeof(CreateDepartmentRequestValidator))]
    public class CreateDepartmentRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }
    }
}
