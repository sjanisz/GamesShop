namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ADMIN_ID = c.Int(nullable: false, identity: true),
                        ADMIN_LOGIN = c.String(nullable: false, maxLength: 15, unicode: false),
                        ADMIN_FIRSTNAME = c.String(nullable: false, maxLength: 50),
                        ADMIN_LASTNAME = c.String(nullable: false, maxLength: 50),
                        ADMIN_TYPE = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                        ADMIN_PASSHASH = c.String(nullable: false, maxLength: 100, unicode: false),
                        ADMIN_SALTHASH = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ADMIN_ID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LANG_ID = c.Int(nullable: false, identity: true),
                        LANG_NAME = c.String(nullable: false, maxLength: 20),
                        LANG_FLAG_URL = c.String(nullable: false, maxLength: 512, unicode: false),
                    })
                .PrimaryKey(t => t.LANG_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        PROD_ID = c.Int(nullable: false, identity: true),
                        PEGI_ID = c.Int(nullable: false),
                        PRODUCENT_ID = c.Int(nullable: false),
                        PROD_NAME = c.String(nullable: false, maxLength: 50),
                        PROD_PRICE = c.Decimal(nullable: false, storeType: "money"),
                        PROD_AVAILABLE_AMOUNT = c.Int(nullable: false),
                        PROD_DESC = c.String(maxLength: 200),
                        PROD_VID_URL = c.String(maxLength: 512, unicode: false),
                    })
                .PrimaryKey(t => t.PROD_ID)
                .ForeignKey("dbo.Pegis", t => t.PEGI_ID, cascadeDelete: true)
                .ForeignKey("dbo.Producents", t => t.PRODUCENT_ID, cascadeDelete: true)
                .Index(t => t.PEGI_ID)
                .Index(t => t.PRODUCENT_ID);
            
            CreateTable(
                "dbo.Pegis",
                c => new
                    {
                        PEGI_ID = c.Int(nullable: false, identity: true),
                        PEGI_IMG_URL = c.String(nullable: false, maxLength: 512, unicode: false),
                        PEGI_VALUE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PEGI_ID);
            
            CreateTable(
                "dbo.Producents",
                c => new
                    {
                        PRODUCENT_ID = c.Int(nullable: false, identity: true),
                        PRODUCENT_NAME = c.String(nullable: false, maxLength: 20),
                        PRODUCENT_DESC = c.String(maxLength: 200),
                        PRODUCENT_COUNTRY = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.PRODUCENT_ID);
            
            CreateTable(
                "dbo.Product_Order",
                c => new
                    {
                        ORD_ID = c.Int(nullable: false),
                        PROD_ID = c.Int(nullable: false),
                        PO_AMOUNT = c.Int(nullable: false),
                        PO_ADDITIONAL_INFO = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => new { t.ORD_ID, t.PROD_ID })
                .ForeignKey("dbo.Orders", t => t.ORD_ID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.PROD_ID, cascadeDelete: true)
                .Index(t => t.ORD_ID)
                .Index(t => t.PROD_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ORD_ID = c.Int(nullable: false, identity: true),
                        USER_ID = c.Int(nullable: false),
                        ORD_INFO = c.String(),
                        ORD_DATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ORD_ID)
                .ForeignKey("dbo.Users", t => t.USER_ID, cascadeDelete: true)
                .Index(t => t.USER_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        USER_ID = c.Int(nullable: false, identity: true),
                        PLACE_ID = c.Int(nullable: false),
                        USER_LOGIN = c.String(nullable: false, maxLength: 15, unicode: false),
                        USER_EMAIL = c.String(nullable: false, maxLength: 320, unicode: false),
                        USER_FIRSTNAME = c.String(nullable: false, maxLength: 50),
                        USER_LASTNAME = c.String(nullable: false, maxLength: 50),
                        USER_POSTCODE = c.String(nullable: false, maxLength: 10, unicode: false),
                        USER_PASSHASH = c.String(nullable: false, maxLength: 100, unicode: false),
                        USER_PASSSALT = c.String(nullable: false, maxLength: 100, unicode: false),
                        USER_REGDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.USER_ID)
                .ForeignKey("dbo.Places", t => t.PLACE_ID, cascadeDelete: true)
                .Index(t => t.PLACE_ID);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PLACE_ID = c.Int(nullable: false, identity: true),
                        PROV_ID = c.Int(nullable: false),
                        PLACE_NAME = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PLACE_ID)
                .ForeignKey("dbo.Provinces", t => t.PROV_ID, cascadeDelete: true)
                .Index(t => t.PROV_ID);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        PROV_ID = c.Int(nullable: false, identity: true),
                        PROV_NAME = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.PROV_ID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        USER_ID = c.Int(nullable: false),
                        PROD_ID = c.Int(nullable: false),
                        REV_DATE = c.DateTime(nullable: false),
                        REV_TEXT = c.String(),
                        REV_RATE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.USER_ID, t.PROD_ID })
                .ForeignKey("dbo.Products", t => t.PROD_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.USER_ID, cascadeDelete: true)
                .Index(t => t.USER_ID)
                .Index(t => t.PROD_ID);
            
            CreateTable(
                "dbo.ProductLanguages",
                c => new
                    {
                        Product_PROD_ID = c.Int(nullable: false),
                        Language_LANG_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_PROD_ID, t.Language_LANG_ID })
                .ForeignKey("dbo.Products", t => t.Product_PROD_ID, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.Language_LANG_ID, cascadeDelete: true)
                .Index(t => t.Product_PROD_ID)
                .Index(t => t.Language_LANG_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_Order", "PROD_ID", "dbo.Products");
            DropForeignKey("dbo.Product_Order", "ORD_ID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "USER_ID", "dbo.Users");
            DropForeignKey("dbo.Reviews", "USER_ID", "dbo.Users");
            DropForeignKey("dbo.Reviews", "PROD_ID", "dbo.Products");
            DropForeignKey("dbo.Users", "PLACE_ID", "dbo.Places");
            DropForeignKey("dbo.Places", "PROV_ID", "dbo.Provinces");
            DropForeignKey("dbo.Products", "PRODUCENT_ID", "dbo.Producents");
            DropForeignKey("dbo.Products", "PEGI_ID", "dbo.Pegis");
            DropForeignKey("dbo.ProductLanguages", "Language_LANG_ID", "dbo.Languages");
            DropForeignKey("dbo.ProductLanguages", "Product_PROD_ID", "dbo.Products");
            DropIndex("dbo.ProductLanguages", new[] { "Language_LANG_ID" });
            DropIndex("dbo.ProductLanguages", new[] { "Product_PROD_ID" });
            DropIndex("dbo.Reviews", new[] { "PROD_ID" });
            DropIndex("dbo.Reviews", new[] { "USER_ID" });
            DropIndex("dbo.Places", new[] { "PROV_ID" });
            DropIndex("dbo.Users", new[] { "PLACE_ID" });
            DropIndex("dbo.Orders", new[] { "USER_ID" });
            DropIndex("dbo.Product_Order", new[] { "PROD_ID" });
            DropIndex("dbo.Product_Order", new[] { "ORD_ID" });
            DropIndex("dbo.Products", new[] { "PRODUCENT_ID" });
            DropIndex("dbo.Products", new[] { "PEGI_ID" });
            DropTable("dbo.ProductLanguages");
            DropTable("dbo.Reviews");
            DropTable("dbo.Provinces");
            DropTable("dbo.Places");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Product_Order");
            DropTable("dbo.Producents");
            DropTable("dbo.Pegis");
            DropTable("dbo.Products");
            DropTable("dbo.Languages");
            DropTable("dbo.Admins");
        }
    }
}
