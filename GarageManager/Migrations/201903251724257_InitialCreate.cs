namespace GarageManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartModels",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ClientID = c.String(),
                    ProductID = c.Int(nullable: false),
                    Amount = c.Int(nullable: false),
                    DatePurchased = c.DateTime(nullable: false),
                    IsInCart = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductModels", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);

            CreateTable(
                "dbo.ProductModels",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    TypeID = c.Int(nullable: false),
                    Name = c.String(),
                    Price = c.Double(nullable: false),
                    Description = c.String(),
                    Image = c.String(),
                    ProductType_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductTypeModels", t => t.ProductType_ID)
                .Index(t => t.ProductType_ID);

            CreateTable(
                "dbo.ProductTypeModels",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.UserDetailModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Guid = c.String(),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Address = c.String(),
                    PostalCode = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.ProductModels", "ProductType_ID", "dbo.ProductTypeModels");
            DropForeignKey("dbo.CartModels", "ProductID", "dbo.ProductModels");
            DropIndex("dbo.ProductModels", new[] { "ProductType_ID" });
            DropIndex("dbo.CartModels", new[] { "ProductID" });
            DropTable("dbo.UserDetailModels");
            DropTable("dbo.ProductTypeModels");
            DropTable("dbo.ProductModels");
            DropTable("dbo.CartModels");
        }
    }
}