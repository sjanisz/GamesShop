namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "USER_STREET", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.User", "USER_FLAT", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.User", "USER_POSTCODE", c => c.String(nullable: false, maxLength: 6, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "USER_POSTCODE", c => c.String(nullable: false, maxLength: 10, unicode: false));
            DropColumn("dbo.User", "USER_FLAT");
            DropColumn("dbo.User", "USER_STREET");
        }
    }
}
