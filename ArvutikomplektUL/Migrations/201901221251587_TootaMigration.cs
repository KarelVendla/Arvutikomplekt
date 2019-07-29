namespace ArvutikomplektUL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TootaMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arvutikomplekts", "Tellimused", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Arvutikomplekts", "Tellimused");
        }
    }
}
