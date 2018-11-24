using System.Data.Entity.Migrations;

namespace MyLibrary.EF.Migrations
{
	public partial class AddAbstract : DbMigration
	{
		public override void Down()
		{
			DropColumn("dbo.Posts", "Abstract");
		}

		public override void Up()
		{
			AddColumn("dbo.Posts", "Abstract", c => c.String());
			Sql("UPDATE dbo.Posts SET Abstract = LEFT(Content, 100) WHERE Abstract IS NULL");
		}
	}
}
