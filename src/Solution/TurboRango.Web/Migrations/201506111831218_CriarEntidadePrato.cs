namespace TurboRango.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarEntidadePrato : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pratoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ingredientes = c.String(),
                        Valor = c.Decimal(precision: 18, scale: 2),
                        DataAtualizacao = c.DateTime(),
                        Restaurante_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurantes", t => t.Restaurante_Id)
                .Index(t => t.Restaurante_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pratoes", "Restaurante_Id", "dbo.Restaurantes");
            DropIndex("dbo.Pratoes", new[] { "Restaurante_Id" });
            DropTable("dbo.Pratoes");
        }
    }
}
