using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.EmployeeAward
{
    internal sealed class AwardEmployeeConfiguration : EntityTypeConfiguration<AwardEmployee>
    {
        public AwardEmployeeConfiguration()
        {
            HasKey(k => new { k.AwardId, k.EmployeeId }).
            ToTable("awards_for_employees");
            Property(s => s.EmployeeId).HasColumnName("award_id");
            Property(s => s.AwardId).HasColumnName("employee_id");
            HasRequired(s => s.Employee)
                .WithMany(i => i.AwardsForEmployees).HasForeignKey(i => i.EmployeeId);
            HasRequired(s => s.Award)
                .WithMany(i => i.AwardsForEmployees).HasForeignKey(i => i.AwardId);
        }
    }
}
