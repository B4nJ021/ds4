namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavoriteGames",
                c => new
                    {
                        FavoriteGameId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        GameName = c.String(maxLength: 200),
                        Company = c.String(maxLength: 100),
                        ReleaseDate = c.DateTime(),
                        ImageUrl = c.String(maxLength: 500),
                        Console = c.String(maxLength: 100),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FavoriteGameId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 255),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.GameSales",
                c => new
                    {
                        SalesId = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        GameName = c.String(maxLength: 200),
                        CopiesSold = c.Int(nullable: false),
                        Revenue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Console = c.String(maxLength: 100),
                        SaleDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavoriteGames", "UserId", "dbo.Users");
            DropIndex("dbo.FavoriteGames", new[] { "UserId" });
            DropTable("dbo.GameSales");
            DropTable("dbo.Users");
            DropTable("dbo.FavoriteGames");
        }
    }
}
