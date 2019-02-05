namespace SendMessage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdPhone = c.Int(nullable: false),
                        AddInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Phones", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessageResepients",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RecepientId = c.Int(nullable: false),
                        MessageId = c.Int(nullable: false),
                        DateTimeCreate = c.DateTime(nullable: false),
                        DateTimeStart = c.DateTime(nullable: false),
                        DateTimeEnd = c.DateTime(nullable: false),
                        Period = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("dbo.Phones", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.MessageId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TextOfMessage = c.String(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        UserPhone = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdInfoes", "Id", "dbo.Phones");
            DropForeignKey("dbo.MessageResepients", "Id", "dbo.Phones");
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropForeignKey("dbo.MessageResepients", "MessageId", "dbo.Messages");
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropIndex("dbo.MessageResepients", new[] { "MessageId" });
            DropIndex("dbo.MessageResepients", new[] { "Id" });
            DropIndex("dbo.AdInfoes", new[] { "Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.MessageResepients");
            DropTable("dbo.Phones");
            DropTable("dbo.AdInfoes");
        }
    }
}
