namespace SistemaGerenciamentoLivros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        IdAutor = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdAutor);
            
            CreateTable(
                "dbo.Editora",
                c => new
                    {
                        IdEditora = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.IdEditora);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        IdLivro = c.Int(nullable: false, identity: true),
                        CodigoLivro = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        AnoLancamento = c.Int(nullable: false),
                        Autor_IdAutor = c.Int(nullable: false),
                        Editora_IdEditora = c.Int(),
                    })
                .PrimaryKey(t => t.IdLivro)
                .ForeignKey("dbo.Autor", t => t.Autor_IdAutor, cascadeDelete: true)
                .ForeignKey("dbo.Editora", t => t.Editora_IdEditora)
                .Index(t => t.Autor_IdAutor)
                .Index(t => t.Editora_IdEditora);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livro", "Editora_IdEditora", "dbo.Editora");
            DropForeignKey("dbo.Livro", "Autor_IdAutor", "dbo.Autor");
            DropIndex("dbo.Livro", new[] { "Editora_IdEditora" });
            DropIndex("dbo.Livro", new[] { "Autor_IdAutor" });
            DropTable("dbo.Livro");
            DropTable("dbo.Editora");
            DropTable("dbo.Autor");
        }
    }
}
