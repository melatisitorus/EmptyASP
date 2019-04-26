namespace EmptyASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmodelTabel7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        price = c.Int(nullable: false),
                        stock = c.Int(nullable: false),
                        suppliers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.suppliers_Id)
                .Index(t => t.suppliers_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "suppliers_Id", "dbo.Suppliers");
            DropIndex("dbo.Items", new[] { "suppliers_Id" });
            DropTable("dbo.Items");
        }
    }
}
