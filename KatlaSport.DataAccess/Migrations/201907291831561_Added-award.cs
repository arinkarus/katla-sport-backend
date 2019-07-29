namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Addedaward : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.customer_records", name: "customer_address", newName: "customer_description");
            CreateTable(
                "dbo.employee_award",
                c => new
                    {
                        employee_award_id = c.Int(nullable: false, identity: true),
                        employee_award_name = c.String(maxLength: 40),
                        employee_award_is_deleted = c.String(nullable: false, maxLength: 300),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.employee_award_id);
        }

        public override void Down()
        {
            DropTable("dbo.employee_award");
            RenameColumn(table: "dbo.customer_records", name: "customer_description", newName: "customer_address");
        }
    }
}
