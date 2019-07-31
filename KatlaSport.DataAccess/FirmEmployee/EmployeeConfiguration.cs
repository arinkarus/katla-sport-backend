using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.FirmEmployee
{
    internal sealed class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("employee");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("employee_id");
            Property(i => i.Name).HasColumnName("employee_name");
            Property(i => i.Surname).HasColumnName("employee_surname");
            Property(i => i.About).HasColumnName("employee_about");
        }
    }
}
