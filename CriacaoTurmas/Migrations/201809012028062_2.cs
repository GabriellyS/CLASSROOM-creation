namespace CriacaoTurmas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Turma", "aluno_matricula", c => c.Int());
            AddColumn("dbo.Turma", "professor_matricula", c => c.Int());
            CreateIndex("dbo.Turma", "aluno_matricula");
            CreateIndex("dbo.Turma", "professor_matricula");
            AddForeignKey("dbo.Turma", "aluno_matricula", "dbo.Aluno", "matricula");
            AddForeignKey("dbo.Turma", "professor_matricula", "dbo.Professor", "matricula");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turma", "professor_matricula", "dbo.Professor");
            DropForeignKey("dbo.Turma", "aluno_matricula", "dbo.Aluno");
            DropIndex("dbo.Turma", new[] { "professor_matricula" });
            DropIndex("dbo.Turma", new[] { "aluno_matricula" });
            DropColumn("dbo.Turma", "professor_matricula");
            DropColumn("dbo.Turma", "aluno_matricula");
        }
    }
}
