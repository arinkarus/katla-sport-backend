using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.AwardManagement
{
    public interface IAwardService
    {

        /// <summary>
        /// Gets an award list.
        /// </summary>
        /// <returns>A <see cref="Task{List{AwardListItem}}"/>.</returns>
        Task<List<AwardListItem>> GetAwardsAsync();

        /// <summary>
        /// Gets an award with specified identifier.
        /// </summary>
        /// <param name="awardId">An award identifier.</param>
        /// <returns>A <see cref="Task{Award}"/>.</returns>
        Task<Award> GetAwardAsync(int awardId);

        /// <summary>
        /// Creates a new award.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateAwardRequest"/>.</param>
        /// <returns>A <see cref="Task{Award}"/>.</returns>
        Task<Award> CreateAwardAsync(UpdateAwardRequest createRequest);

        /// <summary>
        /// Updates an existed award.
        /// </summary>
        /// <param name="awardId">An award identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateAwardRequest"/>.</param>
        /// <returns>A <see cref="Task{Award}"/>.</returns>
        Task<Award> UpdateAwardAsync(int awardId, UpdateAwardRequest updateRequest);

        /// <summary>
        /// Deletes an existed award.
        /// </summary>
        /// <param name="awardId">An award identifier.</param>
        /// <returns><see cref="Task"/>.</returns>
        Task DeleteAwardAsync(int awardId);

        /// <summary>
        /// Sets deleted status for an award.
        /// </summary>
        /// <param name="awardId">An award identifier.</param>
        /// <param name="deletedStatus">Status.</param>
        /// <returns><see cref="Task"/>.</returns>
        Task SetStatusAsync(int awardId, bool deletedStatus);
    }
}
