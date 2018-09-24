namespace CriacaoTurmas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mudanca : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Turma", "aluno_matricula", "dbo.Aluno");
            DropIndex("dbo.Turma", new[] { "aluno_matricula" });
            DropColumn("dbo.Turma", "aluno_matricula");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Turma", "aluno_matricula", c => c.Int());
            CreateIndex("dbo.Turma", "aluno_matricula");
            AddForeignKey("dbo.Turma", "aluno_matricula", "dbo.Aluno", "matricula");
        }
    }
}
