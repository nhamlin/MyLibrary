namespace MyLibrary.EF.Migrations
{
	using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Owner_Username", c => c.String(maxLength: 128));
            CreateIndex("dbo.Blogs", "Owner_Username");
            AddForeignKey("dbo.Blogs", "Owner_Username", "dbo.Users", "Username");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "Owner_Username", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "Owner_Username" });
            DropColumn("dbo.Blogs", "Owner_Username");
        }
    }
}
