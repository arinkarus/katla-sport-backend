namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Migration for adding department table.
    /// </summary>
    public partial class AddedDepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.employee_department",
                c => new
                    {
                        employee_department_id = c.Int(nullable: false, identity: true),
                        employee_department_name = c.String(maxLength: 40),
                        parent_department_id = c.Int(),
                    })
                .PrimaryKey(t => t.employee_department_id)
                .ForeignKey("dbo.employee_department", t => t.parent_department_id)
                .Index(t => t.parent_department_id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.employee_department", "parent_department_id", "dbo.employee_department");
            DropIndex("dbo.employee_department", new[] { "parent_department_id" });
            DropTable("dbo.employee_department");
        }
    }
}
