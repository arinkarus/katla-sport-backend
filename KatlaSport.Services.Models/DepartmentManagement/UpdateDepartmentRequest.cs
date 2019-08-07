using FluentValidation.Attributes;

namespace KatlaSport.Services.DepartmentManagement
{
    [Validator(typeof(UpdateDepartmentRequestValidator))]
    public class UpdateDepartmentRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }
    }
}
