using FluentValidation;

namespace KatlaSport.Services.AwardManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateAwardRequest"/>
    /// </summary>
    public class UpdateAwardRequestValidator : AbstractValidator<UpdateAwardRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAwardRequestValidator"/> class.
        /// </summary>
        public UpdateAwardRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 40);
            RuleFor(r => r.Description).Length(0, 300);
        }
    }
}
