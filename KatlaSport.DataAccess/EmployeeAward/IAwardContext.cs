namespace KatlaSport.DataAccess.EmployeeAward
{
    /// <summary>
    /// Represents a context for customer domain.
    /// </summary>
    public interface IAwardContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Award"/> entities.
        /// </summary>
        IEntitySet<Award> Awards { get; }
    }
}
