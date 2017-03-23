namespace DessertApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Desserts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Dietary = c.String(nullable: false, maxLength: 400),
                        Ingredients = c.String(nullable: false),
                        CookTime = c.Int(nullable: false),
                        PrepTime = c.Int(nullable: false),
                        RecipeMethod = c.String(nullable: false),
                        Servings = c.Int(nullable: false),
                        DessertArtUrl = c.String(),
                        Like = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        User = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Desserts");
        }
    }
}
