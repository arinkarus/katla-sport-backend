namespace KatlaSport.Services.AwardManagement
{
    /// <summary>
    /// Represents an award.
    /// </summary>
    public class Award
    {
        /// <summary>
        /// Gets or sets an award ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets an award name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets an award description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether value is soft deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}

