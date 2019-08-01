namespace KatlaSport.DataAccess.EmployeeAward
{
    internal class AwardContext : DomainContextBase<ApplicationDbContext>, IAwardContext
    {
        public AwardContext(ApplicationDbContext dbContext)
           : base(dbContext)
        {
        }

        public IEntitySet<Award> Awards => GetDbSet<Award>();

        public IEntitySet<AwardEmployee> AwardEmployees => GetDbSet<AwardEmployee>();
    }
}
