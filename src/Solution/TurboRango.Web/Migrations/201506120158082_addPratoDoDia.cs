namespace TurboRango.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPratoDoDia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PratoDoDias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ingredientes = c.String(),
                        Valor = c.Decimal(precision: 18, scale: 2),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Restaurantes", "PratoDoDia_Id", c => c.Int());
            CreateIndex("dbo.Restaurantes", "PratoDoDia_Id");
            AddForeignKey("dbo.Restaurantes", "PratoDoDia_Id", "dbo.PratoDoDias", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurantes", "PratoDoDia_Id", "dbo.PratoDoDias");
            DropIndex("dbo.Restaurantes", new[] { "PratoDoDia_Id" });
            DropColumn("dbo.Restaurantes", "PratoDoDia_Id");
            DropTable("dbo.PratoDoDias");
        }
    }
}
