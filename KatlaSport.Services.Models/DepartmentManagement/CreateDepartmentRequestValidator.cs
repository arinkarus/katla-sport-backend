using FluentValidation;

namespace KatlaSport.Services.DepartmentManagement
{
    /// <summary>
    /// Represents a validator for <see cref="CreateAwardRequest"/>
    /// </summary>
    public class CreateDepartmentRequestValidator : AbstractValidator<CreateDepartmentRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateDepartmentRequestValidator"/> class.
        /// </summary>
        public CreateDepartmentRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 40);
            RuleFor(r => r.Description).Length(0, 300);
        }
    }
}
