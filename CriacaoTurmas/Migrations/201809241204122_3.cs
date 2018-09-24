namespace CriacaoTurmas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Turma_Materia", c => c.String(maxLength: 128));
            CreateIndex("dbo.Aluno", "Turma_Materia");
            AddForeignKey("dbo.Aluno", "Turma_Materia", "dbo.Turma", "Materia");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluno", "Turma_Materia", "dbo.Turma");
            DropIndex("dbo.Aluno", new[] { "Turma_Materia" });
            DropColumn("dbo.Aluno", "Turma_Materia");
        }
    }
}
