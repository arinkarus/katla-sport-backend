namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Migration for adding is deleted property to depatment.
    /// </summary>
    public partial class AddedDepartmentIsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.employee_department", "employee_department_is_deleted", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.employee_department", "employee_department_is_deleted");
        }
    }
}
