namespace OptionsWebsite.Migrations.BCITMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Choices", "StudentId", c => c.String());
            AlterColumn("dbo.Options", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Options", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Choices", "StudentId", c => c.String(maxLength: 9));
        }
    }
}
