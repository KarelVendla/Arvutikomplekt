namespace ArvutikomplektUL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalDb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Arvutikomplekts", "Komplekteeritud");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arvutikomplekts", "Komplekteeritud", c => c.Int(nullable: false));
        }
    }
}
