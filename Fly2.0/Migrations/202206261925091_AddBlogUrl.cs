namespace Fly2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogUrl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        Id_Administrator = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                        NumberEmployee = c.String(),
                    })
                .PrimaryKey(t => t.Id_Administrator);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id_User = c.Int(nullable: false, identity: true),
                        Id_Address = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                        Sex = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        ParticipantNumber = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id_User);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Administrators");
        }
    }
}
