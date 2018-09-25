namespace CriacaoTurmas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustandoCamposTurma : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Turma", "professor_matricula", "dbo.Professor");
            DropForeignKey("dbo.Aluno", "Turma_Materia", "dbo.Turma");
            DropIndex("dbo.Aluno", new[] { "Turma_Materia" });
            DropIndex("dbo.Turma", new[] { "professor_matricula" });
            RenameColumn(table: "dbo.Aluno", name: "Turma_Materia", newName: "Turma_TurmaID");
            RenameColumn(table: "dbo.Turma", name: "professor_matricula", newName: "matriculaProfessor");
            DropPrimaryKey("dbo.Turma");
            AddColumn("dbo.Turma", "TurmaID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Aluno", "Turma_TurmaID", c => c.Int());
            AlterColumn("dbo.Turma", "Materia", c => c.String());
            AlterColumn("dbo.Turma", "matriculaProfessor", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Turma", "TurmaID");
            CreateIndex("dbo.Aluno", "Turma_TurmaID");
            CreateIndex("dbo.Turma", "matriculaProfessor");
            AddForeignKey("dbo.Turma", "matriculaProfessor", "dbo.Professor", "matricula", cascadeDelete: true);
            AddForeignKey("dbo.Aluno", "Turma_TurmaID", "dbo.Turma", "TurmaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluno", "Turma_TurmaID", "dbo.Turma");
            DropForeignKey("dbo.Turma", "matriculaProfessor", "dbo.Professor");
            DropIndex("dbo.Turma", new[] { "matriculaProfessor" });
            DropIndex("dbo.Aluno", new[] { "Turma_TurmaID" });
            DropPrimaryKey("dbo.Turma");
            AlterColumn("dbo.Turma", "matriculaProfessor", c => c.Int());
            AlterColumn("dbo.Turma", "Materia", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Aluno", "Turma_TurmaID", c => c.String(maxLength: 128));
            DropColumn("dbo.Turma", "TurmaID");
            AddPrimaryKey("dbo.Turma", "Materia");
            RenameColumn(table: "dbo.Turma", name: "matriculaProfessor", newName: "professor_matricula");
            RenameColumn(table: "dbo.Aluno", name: "Turma_TurmaID", newName: "Turma_Materia");
            CreateIndex("dbo.Turma", "professor_matricula");
            CreateIndex("dbo.Aluno", "Turma_Materia");
            AddForeignKey("dbo.Aluno", "Turma_Materia", "dbo.Turma", "Materia");
            AddForeignKey("dbo.Turma", "professor_matricula", "dbo.Professor", "matricula");
        }
    }
}
