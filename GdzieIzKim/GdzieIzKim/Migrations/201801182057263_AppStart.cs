namespace GdzieIzKim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kat",
                c => new
                    {
                        KategoriaId = c.Int(nullable: false, identity: true),
                        NazwaKat = c.String(),
                        OpisKat = c.String(),
                    })
                .PrimaryKey(t => t.KategoriaId);
            
            CreateTable(
                "dbo.Lok",
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
                .ForeignKey("dbo.Kat", t => t.KategoriaId, cascadeDelete: true)
                .Index(t => t.KategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lok", "KategoriaId", "dbo.Kat");
            DropIndex("dbo.Lok", new[] { "KategoriaId" });
            DropTable("dbo.Lok");
            DropTable("dbo.Kat");
        }
    }
}
