namespace ProvaConhecimento.Stefanini.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        IdCity = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IdRegion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCity)
                .ForeignKey("dbo.Regions", t => t.IdRegion, cascadeDelete: true)
                .Index(t => t.IdRegion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "IdRegion", "dbo.Regions");
            DropIndex("dbo.Cities", new[] { "IdRegion" });
            DropTable("dbo.Cities");
        }
    }
}
