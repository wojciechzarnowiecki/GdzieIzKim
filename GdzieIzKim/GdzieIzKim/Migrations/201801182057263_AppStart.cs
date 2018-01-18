namespace GdzieIzKim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategorias",
                c => new
                    {
                        KategoriaId = c.Int(nullable: false, identity: true),
                        NazwaKat = c.String(),
                        OpisKat = c.String(),
                    })
                .PrimaryKey(t => t.KategoriaId);
            
            CreateTable(
                "dbo.Lokalizacjas",
                c => new
                    {
                        LokalizacjaId = c.Int(nullable: false, identity: true),
                        NazwaLoc = c.String(),
                        AdresLoc = c.String(),
                        InformacjeLoc = c.String(),
                        SzerokoscLoc = c.String(),
                        DlugoscLoc = c.String(),
                        KategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LokalizacjaId)
                .ForeignKey("dbo.Kategorias", t => t.KategoriaId, cascadeDelete: true)
                .Index(t => t.KategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lokalizacjas", "KategoriaId", "dbo.Kategorias");
            DropIndex("dbo.Lokalizacjas", new[] { "KategoriaId" });
            DropTable("dbo.Lokalizacjas");
            DropTable("dbo.Kategorias");
        }
    }
}
