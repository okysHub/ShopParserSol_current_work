namespace ShopParser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductPriceHistories", "UpdateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductPriceHistories", "UpdateDate", c => c.DateTime(nullable: false));
        }
    }
}
