namespace InternalMoney.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_Sender = c.Int(nullable: false),
                        Id_Receiver = c.Int(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Receiver_Id = c.Int(),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Receiver_Id)
                .ForeignKey("dbo.Users", t => t.Sender_Id)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id);
            
            AddColumn("dbo.Users", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.Transactions", "Receiver_Id", "dbo.Users");
            DropIndex("dbo.Transactions", new[] { "Sender_Id" });
            DropIndex("dbo.Transactions", new[] { "Receiver_Id" });
            DropColumn("dbo.Users", "Balance");
            DropTable("dbo.Transactions");
        }
    }
}
