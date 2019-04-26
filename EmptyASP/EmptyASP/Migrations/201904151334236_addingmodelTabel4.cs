namespace EmptyASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmodelTabel4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Suppliers", "IsDelete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "IsDelete", c => c.Boolean(nullable: false));
        }
    }
}
