using FluentValidation;

namespace KatlaSport.Services.EmployeeManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateEmployeeRequest"/>
    /// </summary>
    public class UpdateEmployeeRequestValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEmployeeRequestValidator"/> class.
        /// </summary>
        public UpdateEmployeeRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 40);
            RuleFor(r => r.Surname).Length(4, 40);
            RuleFor(r => r.Email).Length(4, 125);
            RuleFor(r => r.Surname).Length(4, 40);
            RuleFor(r => r.About).Length(0, 300);
        }
    }
}
