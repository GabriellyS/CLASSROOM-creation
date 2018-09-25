namespace CriacaoTurmas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustandoNomeTurma : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Turma", "Nome_turma", c => c.String());
            DropColumn("dbo.Turma", "Materia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Turma", "Materia", c => c.String());
            DropColumn("dbo.Turma", "Nome_turma");
        }
    }
}
