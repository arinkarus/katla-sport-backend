namespace KatlaSport.DataAccess.FirmEmployee
{
    /// <summary>
    /// Represents a context for employee domain.
    /// </summary>
    public interface IEmployeeContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Employee"/> entities.
        /// </summary>
        IEntitySet<Employee> Employees { get; }
    }
}