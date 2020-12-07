namespace ProvaConhecimento.Stefanini.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassificationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classifications",
                c => new
                    {
                        IdClassification = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdClassification);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Classifications");
        }
    }
}
