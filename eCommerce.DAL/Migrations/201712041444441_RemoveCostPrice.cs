namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCostPrice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ProductPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
