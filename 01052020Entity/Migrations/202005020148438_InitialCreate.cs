namespace _01052020Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdMarca = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.IdMarca, cascadeDelete: true)
                .Index(t => t.IdMarca);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "IdMarca", "dbo.Marcas");
            DropIndex("dbo.Produtos", new[] { "IdMarca" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Marcas");
        }
    }
}
