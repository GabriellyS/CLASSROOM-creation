namespace CriacaoTurmas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "telefone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "telefone");
        }
    }
}
