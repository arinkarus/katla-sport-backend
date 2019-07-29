using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.EmployeeAward;
using DbAward = KatlaSport.DataAccess.EmployeeAward.Award;

namespace KatlaSport.Services.AwardManagement
{
    /// <summary>
    /// Represents an award service.
    /// </summary>
    public class AwardService : IAwardService
    {
        private IAwardContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AwardService"/> class with specified <see cref="IAwardContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IAwardContext"/>.</param>
        public AwardService(IAwardContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<AwardListItem>> GetAwardsAsync()
        {
            var dbAwards = await _context.Awards.OrderBy(a => a.Id).ToArrayAsync();
            var awards = dbAwards.Select(a => Mapper.Map<AwardListItem>(a)).ToList();
            return awards;
        }

        /// <inheritdoc/>
        public async Task<Award> GetAwardAsync(int awardId)
        {
            var dbAward = await _context.Awards.Where(a => a.Id == awardId).ToArrayAsync();
            if (dbAward.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<Award>(dbAward);
        }

        /// <inheritdoc/>
        public async Task<Award> CreateAwardAsync(UpdateAwardRequest createRequest)
        {
            var dbAward = Mapper.Map<UpdateAwardRequest, DbAward>(createRequest);
            _context.Awards.Add(dbAward);
            await _context.SaveChangesAsync();
            return Mapper.Map<Award>(dbAward);
        }

        /// <inheritdoc/>
        public async Task<Award> UpdateAwardAsync(int awardId, UpdateAwardRequest updateRequest)
        {
            var dbAwards = await _context.Awards.Where(a => a.Id == awardId).ToArrayAsync();
            if (dbAwards.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbAward = dbAwards[0];
            Mapper.Map(updateRequest, dbAward);

            await _context.SaveChangesAsync();
            return Mapper.Map<Award>(dbAward);
        }

        /// <inheritdoc/>
        public async Task DeleteAwardAsync(int awardId)
        {
            var dbAwards = await _context.Awards.Where(a => a.Id == awardId).ToArrayAsync();
            if (dbAwards.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbAward = dbAwards[0];
            //todo: check that employees don't have this award
            _context.Awards.Remove(dbAward);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task SetStatusAsync(int awardId, bool deletedStatus)
        {
            var dbAwards = await _context.Awards.Where(a => a.Id == awardId).ToArrayAsync();
            if (dbAwards.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbAward = dbAwards[0];
            if (dbAward.IsDeleted != deletedStatus)
            {
                dbAward.IsDeleted = deletedStatus;
                await _context.SaveChangesAsync();
            }
        }
    }
}
