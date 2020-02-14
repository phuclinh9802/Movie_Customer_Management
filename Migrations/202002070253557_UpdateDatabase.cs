namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenresTypes",
                c => new
                    {
                        GenresTypeId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenresTypeId);
            
            CreateTable(
                "dbo.MoviesToSees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseDate = c.String(nullable: false),
                        DateAdded = c.String(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                        GenresTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenresTypes", t => t.GenresTypeId, cascadeDelete: true)
                .Index(t => t.GenresTypeId);
            
            DropTable("dbo.Movies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.String(nullable: false),
                        ReleaseDate = c.String(nullable: false),
                        DateAdded = c.String(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.MoviesToSees", "GenresTypeId", "dbo.GenresTypes");
            DropIndex("dbo.MoviesToSees", new[] { "GenresTypeId" });
            DropTable("dbo.MoviesToSees");
            DropTable("dbo.GenresTypes");
        }
    }
}
