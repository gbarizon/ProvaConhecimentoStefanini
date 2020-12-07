namespace ProvaConhecimento.Stefanini.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IdClassification", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "IdGender", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "IdCity", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "IdRegion", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "IdClassification");
            CreateIndex("dbo.Customers", "IdGender");
            CreateIndex("dbo.Customers", "IdCity");
            CreateIndex("dbo.Customers", "IdRegion");
            AddForeignKey("dbo.Customers", "IdCity", "dbo.Cities", "IdCity");
            AddForeignKey("dbo.Customers", "IdClassification", "dbo.Classifications", "IdClassification");
            AddForeignKey("dbo.Customers", "IdGender", "dbo.Genders", "IdGender");
            AddForeignKey("dbo.Customers", "IdRegion", "dbo.Regions", "IdRegion");
            DropColumn("dbo.Customers", "Classification");
            DropColumn("dbo.Customers", "Gender");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Region");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Region", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Customers", "City", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Customers", "Gender", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Customers", "Classification", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.Customers", "IdRegion", "dbo.Regions");
            DropForeignKey("dbo.Customers", "IdGender", "dbo.Genders");
            DropForeignKey("dbo.Customers", "IdClassification", "dbo.Classifications");
            DropForeignKey("dbo.Customers", "IdCity", "dbo.Cities");
            DropIndex("dbo.Customers", new[] { "IdRegion" });
            DropIndex("dbo.Customers", new[] { "IdCity" });
            DropIndex("dbo.Customers", new[] { "IdGender" });
            DropIndex("dbo.Customers", new[] { "IdClassification" });
            DropColumn("dbo.Customers", "IdRegion");
            DropColumn("dbo.Customers", "IdCity");
            DropColumn("dbo.Customers", "IdGender");
            DropColumn("dbo.Customers", "IdClassification");
        }
    }
}
