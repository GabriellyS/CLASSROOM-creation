namespace CriacaoTurmas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacao4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Turma", "Horario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Turma", "Horario", c => c.DateTime(nullable: false));
        }
    }
}
