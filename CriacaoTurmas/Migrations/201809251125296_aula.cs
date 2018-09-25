namespace CriacaoTurmas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aula : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        matricula = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        telefone = c.String(),
                        Turma_Materia = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.matricula)
                .ForeignKey("dbo.Turma", t => t.Turma_Materia)
                .Index(t => t.Turma_Materia);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        matricula = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        disciplina = c.String(),
                    })
                .PrimaryKey(t => t.matricula);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        Materia = c.String(nullable: false, maxLength: 128),
                        professor_matricula = c.Int(),
                    })
                .PrimaryKey(t => t.Materia)
                .ForeignKey("dbo.Professor", t => t.professor_matricula)
                .Index(t => t.professor_matricula);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turma", "professor_matricula", "dbo.Professor");
            DropForeignKey("dbo.Aluno", "Turma_Materia", "dbo.Turma");
            DropIndex("dbo.Turma", new[] { "professor_matricula" });
            DropIndex("dbo.Aluno", new[] { "Turma_Materia" });
            DropTable("dbo.Turma");
            DropTable("dbo.Professor");
            DropTable("dbo.Aluno");
        }
    }
}
