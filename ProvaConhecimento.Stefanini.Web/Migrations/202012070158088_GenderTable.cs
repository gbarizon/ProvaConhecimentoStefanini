namespace ProvaConhecimento.Stefanini.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        IdGender = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdGender);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Genders");
        }
    }
}
