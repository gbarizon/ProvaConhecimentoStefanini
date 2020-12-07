namespace ProvaConhecimento.Stefanini.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        IdCustomer = c.Int(nullable: false, identity: true),
                        Classification = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 100),
                        Region = c.String(nullable: false, maxLength: 100),
                        LastPurchase = c.DateTime(),
                        IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCustomer)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser);
            
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "IdUser", "dbo.Users");
            DropIndex("dbo.Customers", new[] { "IdUser" });
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));            
        }
    }
}
