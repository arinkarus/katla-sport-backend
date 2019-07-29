using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.EmployeeAward
{
    internal sealed class AwardConfiguration : EntityTypeConfiguration<Award>
    {
        public AwardConfiguration()
        {
            ToTable("employee_award");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("employee_award_id");
            Property(i => i.Name).HasColumnName("employee_award_name").HasMaxLength(40);
            Property(i => i.Description).HasColumnName("employee_award_description").HasMaxLength(300);
            Property(i => i.Description).HasColumnName("employee_award_is_deleted").IsRequired();
        }
    }
}
