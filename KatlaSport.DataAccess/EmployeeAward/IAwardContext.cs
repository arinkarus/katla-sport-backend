using KatlaSport.DataAccess.FirmEmployee;

namespace KatlaSport.DataAccess.EmployeeAward
{
    /// <summary>
    /// Represents a context for award domain.
    /// </summary>
    public interface IAwardContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Award"/> entities.
        /// </summary>
        IEntitySet<Award> Awards { get; }

        IEntitySet<AwardEmployee> AwardEmployees { get; }
    }
}
