namespace ShopParser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "MenuUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "MenuUrl");
        }
    }
}
