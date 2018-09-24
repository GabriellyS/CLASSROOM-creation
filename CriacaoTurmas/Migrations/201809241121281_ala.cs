namespace CriacaoTurmas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ala : DbMigration
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
                    })
                .PrimaryKey(t => t.matricula);
            
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
                        aluno_matricula = c.Int(),
                        professor_matricula = c.Int(),
                    })
                .PrimaryKey(t => t.Materia)
                .ForeignKey("dbo.Aluno", t => t.aluno_matricula)
                .ForeignKey("dbo.Professor", t => t.professor_matricula)
                .Index(t => t.aluno_matricula)
                .Index(t => t.professor_matricula);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turma", "professor_matricula", "dbo.Professor");
            DropForeignKey("dbo.Turma", "aluno_matricula", "dbo.Aluno");
            DropIndex("dbo.Turma", new[] { "professor_matricula" });
            DropIndex("dbo.Turma", new[] { "aluno_matricula" });
            DropTable("dbo.Turma");
            DropTable("dbo.Professor");
            DropTable("dbo.Aluno");
        }
    }
}
