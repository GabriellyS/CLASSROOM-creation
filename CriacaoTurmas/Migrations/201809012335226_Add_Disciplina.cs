namespace CriacaoTurmas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Disciplina : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Professor", "disciplina", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Professor", "disciplina");
        }
    }
}
