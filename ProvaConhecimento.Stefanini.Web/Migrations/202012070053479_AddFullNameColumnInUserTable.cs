namespace ProvaConhecimento.Stefanini.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFullNameColumnInUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FullName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "FullName");
        }
    }
}
