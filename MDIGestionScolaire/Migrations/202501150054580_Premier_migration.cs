namespace MDIGestionScolaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Premier_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Etudiants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        IdClasse = c.Int(nullable: false),
                        Classe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Classe_Id)
                .Index(t => t.Classe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Etudiants", "Classe_Id", "dbo.Classes");
            DropIndex("dbo.Etudiants", new[] { "Classe_Id" });
            DropTable("dbo.Etudiants");
            DropTable("dbo.Classes");
        }
    }
}
