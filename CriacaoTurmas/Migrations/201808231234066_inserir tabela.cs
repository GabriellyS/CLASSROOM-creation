namespace CriacaoTurmas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inserirtabela : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        matricula = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.matricula);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        matricula = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.matricula);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        Materia = c.String(nullable: false, maxLength: 128),
                        Horario = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Materia);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Turma");
            DropTable("dbo.Professor");
            DropTable("dbo.Aluno");
        }
    }
}
