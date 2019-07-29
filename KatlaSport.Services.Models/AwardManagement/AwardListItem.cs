namespace KatlaSport.Services.AwardManagement
{
    /// <summary>
    /// Represents an award list item.
    /// </summary>
    public class AwardListItem
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
    }
}
