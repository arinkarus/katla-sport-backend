using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.DepartmentManagement
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Gets a department list.
        /// </summary>
        /// <returns>A <see cref="Task{List{DepartmentListItem}}"/>.</returns>
        Task<List<DepartmentListItem>> GetDepartmentsAsync();

        /// <summary>
        /// Gets a department by id.
        /// </summary>
        /// <param name="id">An department identifier.</param>
        /// <returns>A <see cref="Task{List{UpdateDepartmentData}}"/>.</returns>
        Task<UpdateDepartmentData> GetDepartmentByIdAsync(int id);

        /// <summary>
        /// Gets a parent department list.
        /// </summary>
        /// <returns>A <see cref="Task{List{DepartmentSelectItem}}"/>.</returns>
        Task<List<DepartmentSelectItem>> GetParentDepartmentsAsync();

        /// <summary>
        /// Gets child departments.
        /// </summary>
        /// <param name="id">An parent department identifier.</param>
        /// <returns>A <see cref="Task{List{DepartmentSelectItem}}"/>.</returns>
        Task<List<DepartmentSelectItem>> GetChildDepartmentsAsync(int id);

        /// <summary>
        /// Deletes an existed department.
        /// </summary>
        /// <param name="id">An department identifier.</param>
        /// <returns><see cref="Task"/>.</returns>
        Task DeleteDepartmentAsync(int id);

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="createRequest">A <see cref="CreateDepartmentRequest"/>.</param>
        /// <returns>A <see cref="Task{Department}"/>.</returns>
        Task<Department> CreateDepartmentAsync(CreateDepartmentRequest createRequest);

        /// <summary>
        /// Updates an existed department.
        /// </summary>
        /// <param name="awardId">An award identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateAwardRequest"/>.</param>
        /// <returns>A <see cref="Task{Award}"/>.</returns>
        Task<Department> UpdateDepartmentAsync(int awardId, UpdateDepartmentRequest updateRequest);
    }
}
