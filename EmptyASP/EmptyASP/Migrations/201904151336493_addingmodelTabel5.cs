namespace EmptyASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmodelTabel5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "IsDelete");
        }
    }
}
