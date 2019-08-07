using System.Collections.Generic;
using System.Threading.Tasks;
using KatlaSport.Services.ImageManagement;

namespace KatlaSport.Services.EmployeeManagement
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets an employee list.
        /// </summary>
        /// <returns>A <see cref="Task{List{EmployeeListItem}}"/>.</returns>
        Task<List<EmployeeListItem>> GetEmployeesAsync();

        /// <summary>
        /// Gets an employee with specified identifier.
        /// </summary>
        /// <param name="id">An employee identifier.</param>
        /// <returns>A <see cref="Task{UpdateEmployeeData}"/>.</returns>
        Task<UpdateEmployeeData> GetEmployeeAsync(int id);

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateEmployeeRequest"/>.</param>
        /// <returns>A <see cref="Task{Employee}"/>.</returns>
        Task<Employee> CreateEmployeeAsync(UpdateEmployeeRequest createRequest);

        /// <summary>
        /// Deletes an employee.
        /// </summary>
        /// <param name="id">An employee identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteEmployeeAsync(int id);

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">An employee identifier.</param>
        /// <param name="updateEmployeeRequest">An employee data.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task UpdateEmployeeAsync(int id, UpdateEmployeeRequest updateEmployeeRequest);

        /// <summary>
        /// Gets an employee profile with specified identifier.
        /// </summary>
        /// <param name="id">An employee identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task<EmployeeProfile> GetEmployeeProfileById(int id);

        /// <summary>
        /// Updates employee's photo.
        /// </summary>
        /// <param name="id">Employee id.</param>
        /// <param name="data">Image data.</param>
        /// <param name="imageService">Service for manipulation with images.</param>
        /// <returns>A <see cref="Task{ImageResult}"/>.</returns>
        Task<ImageResult> UpdateEmployeePhotoAsync(int id, ImageData data, IImageService imageService);

        /// <summary>
        /// Deletes photo of employee.
        /// </summary>
        /// <param name="id">Employee id.</param>
        /// <param name="imageService">Service for manipulation with images.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteEmployeePhotoAsync(int id, IImageService imageService);
    }
}
