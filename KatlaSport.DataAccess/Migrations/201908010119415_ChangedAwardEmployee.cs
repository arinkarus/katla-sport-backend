namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangedAwardEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeAwards", "Employee_Id", "dbo.employee");
            DropForeignKey("dbo.EmployeeAwards", "Award_Id", "dbo.employee_award");
            DropIndex("dbo.EmployeeAwards", new[] { "Employee_Id" });
            DropIndex("dbo.EmployeeAwards", new[] { "Award_Id" });
            CreateTable(
                "dbo.awards_for_employees",
                c => new
                    {
                        employee_id = c.Int(nullable: false),
                        award_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.employee_id, t.award_id })
                .ForeignKey("dbo.employee_award", t => t.employee_id, cascadeDelete: true)
                .ForeignKey("dbo.employee", t => t.award_id, cascadeDelete: true)
                .Index(t => t.employee_id)
                .Index(t => t.award_id);
            DropTable("dbo.award_for_employee");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeAwards",
                c => new
                    {
                        Employee_Id = c.Int(nullable: false),
                        Award_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_Id, t.Award_Id });
            DropForeignKey("dbo.awards_for_employees", "award_id", "dbo.employee");
            DropForeignKey("dbo.awards_for_employees", "employee_id", "dbo.employee_award");
            DropIndex("dbo.awards_for_employees", new[] { "award_id" });
            DropIndex("dbo.awards_for_employees", new[] { "employee_id" });
            DropTable("dbo.awards_for_employees");
            CreateIndex("dbo.EmployeeAwards", "Award_Id");
            CreateIndex("dbo.EmployeeAwards", "Employee_Id");
            AddForeignKey("dbo.EmployeeAwards", "Award_Id", "dbo.employee_award", "employee_award_id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeAwards", "Employee_Id", "dbo.employee", "employee_id", cascadeDelete: true);
        }
    }
}
