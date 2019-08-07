namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Migration for adding description for department.
    /// </summary>
    public partial class AddedDescriptionForDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.employee_department", "employee_department_description", c => c.String(maxLength: 200));
        }

        public override void Down()
        {
            DropColumn("dbo.employee_department", "employee_department_description");
        }
    }
}
