using FluentValidation.Attributes;

namespace KatlaSport.Services.AwardManagement
{
    [Validator(typeof(UpdateAwardRequestValidator))]
    public class UpdateAwardRequest
    {
        /// <summary>
        /// Gets or sets an award name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets an award description.
        /// </summary>
        public string Description { get; set; }
    }
}
