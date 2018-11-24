using System.Data.Entity.Migrations;

namespace MyLibrary.EF.Migrations
{
	public partial class AddPostClass : DbMigration
	{
		public override void Down()
		{
			// Note: Dropped index (note the IX_ in front)
			DropIndex("dbo.Posts", "IX_Title");
			AlterColumn("dbo.Posts", "Title", c => c.String());
			DropColumn("dbo.Blogs", "Rating");
		}

		public override void Up()
		{
			// Note: Added default Value
			AddColumn("dbo.Blogs", "Rating", c => c.Int(nullable: false, defaultValue: 3));
			AlterColumn("dbo.Posts", "Title", c => c.String(maxLength: 100));
			// Note: Added index
			CreateIndex("dbo.Posts", "Title", unique: true);
		}
	}
}
