namespace EmptyASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmodeltabel15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "IsDelete");
        }
    }
}
