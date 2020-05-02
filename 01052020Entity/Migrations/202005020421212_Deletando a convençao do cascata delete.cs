namespace _01052020Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deletandoaconvençaodocascatadelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtos", "IdMarca", "dbo.Marcas");
            AddForeignKey("dbo.Produtos", "IdMarca", "dbo.Marcas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "IdMarca", "dbo.Marcas");
            AddForeignKey("dbo.Produtos", "IdMarca", "dbo.Marcas", "Id", cascadeDelete: true);
        }
    }
}
