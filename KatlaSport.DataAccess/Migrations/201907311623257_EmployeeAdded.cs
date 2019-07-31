namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EmployeeAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.employee",
                c => new
                    {
                        employee_id = c.Int(nullable: false, identity: true),
                        employee_name = c.String(),
                        employee_surname = c.String(),
                        Email = c.String(),
                        employee_about = c.String(),
                    })
                .PrimaryKey(t => t.employee_id);
            CreateTable(
                "dbo.award_for_employee",
                c => new
                    {
                        Employee_Id = c.Int(nullable: false),
                        Award_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_Id, t.Award_Id })
                .ForeignKey("dbo.employee", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("dbo.employee_award", t => t.Award_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id)
                .Index(t => t.Award_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.EmployeeAwards", "Award_Id", "dbo.employee_award");
            DropForeignKey("dbo.EmployeeAwards", "Employee_Id", "dbo.employee");
            DropIndex("dbo.EmployeeAwards", new[] { "Award_Id" });
            DropIndex("dbo.EmployeeAwards", new[] { "Employee_Id" });
            DropTable("dbo.EmployeeAwards");
            DropTable("dbo.employee");
        }
    }
}
