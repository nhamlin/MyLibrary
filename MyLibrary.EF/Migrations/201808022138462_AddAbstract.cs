namespace MyLibrary.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAbstract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Abstract", c => c.String());
			Sql("UPDATE dbo.Posts SET Abstract = LEFT(Content, 100) WHERE Abstract IS NULL");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Abstract");
        }
    }
}
