namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class uniqueUserLogin : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.User", "USER_LOGIN", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "USER_LOGIN" });
        }
    }
}
