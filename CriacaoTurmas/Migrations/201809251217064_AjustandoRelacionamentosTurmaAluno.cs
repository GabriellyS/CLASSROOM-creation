namespace CriacaoTurmas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustandoRelacionamentosTurmaAluno : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Aluno", "Turma_TurmaID", "dbo.Turma");
            DropIndex("dbo.Aluno", new[] { "Turma_TurmaID" });
            CreateTable(
                "dbo.TurmaAlunoes",
                c => new
                    {
                        Turma_TurmaID = c.Int(nullable: false),
                        Aluno_matricula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Turma_TurmaID, t.Aluno_matricula })
                .ForeignKey("dbo.Turma", t => t.Turma_TurmaID, cascadeDelete: true)
                .ForeignKey("dbo.Aluno", t => t.Aluno_matricula, cascadeDelete: true)
                .Index(t => t.Turma_TurmaID)
                .Index(t => t.Aluno_matricula);
            
            DropColumn("dbo.Aluno", "Turma_TurmaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluno", "Turma_TurmaID", c => c.Int());
            DropForeignKey("dbo.TurmaAlunoes", "Aluno_matricula", "dbo.Aluno");
            DropForeignKey("dbo.TurmaAlunoes", "Turma_TurmaID", "dbo.Turma");
            DropIndex("dbo.TurmaAlunoes", new[] { "Aluno_matricula" });
            DropIndex("dbo.TurmaAlunoes", new[] { "Turma_TurmaID" });
            DropTable("dbo.TurmaAlunoes");
            CreateIndex("dbo.Aluno", "Turma_TurmaID");
            AddForeignKey("dbo.Aluno", "Turma_TurmaID", "dbo.Turma", "TurmaID");
        }
    }
}
