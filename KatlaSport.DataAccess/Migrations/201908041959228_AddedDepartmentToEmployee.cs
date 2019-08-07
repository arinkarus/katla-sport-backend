namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Migration for adding department property to employee.
    /// </summary>
    public partial class AddedDepartmentToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.employee", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.employee", "DepartmentId");
            AddForeignKey("dbo.employee", "DepartmentId", "dbo.employee_department", "employee_department_id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.employee", "DepartmentId", "dbo.employee_department");
            DropIndex("dbo.employee", new[] { "DepartmentId" });
            DropColumn("dbo.employee", "DepartmentId");
        }
    }
}
