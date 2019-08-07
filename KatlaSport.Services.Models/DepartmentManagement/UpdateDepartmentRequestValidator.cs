using FluentValidation;

namespace KatlaSport.Services.DepartmentManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateDepartmentRequest"/>
    /// </summary>
    public class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateDepartmentRequestValidator"/> class.
        /// </summary>
        public UpdateDepartmentRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 40);
            RuleFor(r => r.Description).Length(0, 200);
        }
    }
}
