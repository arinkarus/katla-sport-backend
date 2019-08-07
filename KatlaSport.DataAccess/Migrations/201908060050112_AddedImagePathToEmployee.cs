namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Migration for adding image path to employee.
    /// </summary>
    public partial class AddedImagePathToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.employee", "ImagePath", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.employee", "ImagePath");
        }
    }
}
