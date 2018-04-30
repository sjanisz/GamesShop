namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SingularForm : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Admins", newName: "Admin");
            RenameTable(name: "dbo.Languages", newName: "Language");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.Pegis", newName: "Pegi");
            RenameTable(name: "dbo.Producents", newName: "Producent");
            RenameTable(name: "dbo.Orders", newName: "Order");
            RenameTable(name: "dbo.Users", newName: "User");
            RenameTable(name: "dbo.Places", newName: "Place");
            RenameTable(name: "dbo.Provinces", newName: "Province");
            RenameTable(name: "dbo.Reviews", newName: "Review");
            RenameTable(name: "dbo.ProductLanguages", newName: "ProductLanguage");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProductLanguage", newName: "ProductLanguages");
            RenameTable(name: "dbo.Review", newName: "Reviews");
            RenameTable(name: "dbo.Province", newName: "Provinces");
            RenameTable(name: "dbo.Place", newName: "Places");
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.Order", newName: "Orders");
            RenameTable(name: "dbo.Producent", newName: "Producents");
            RenameTable(name: "dbo.Pegi", newName: "Pegis");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Language", newName: "Languages");
            RenameTable(name: "dbo.Admin", newName: "Admins");
        }
    }
}
