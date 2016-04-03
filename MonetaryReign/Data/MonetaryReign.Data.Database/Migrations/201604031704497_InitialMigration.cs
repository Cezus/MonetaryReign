namespace MonetaryReign.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AccountIban = c.String(),
                        Bank = c.String(),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(),
                        ContraAccount = c.String(),
                        TransactionSort = c.String(),
                        Positive = c.Boolean(nullable: false),
                        Ammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Message = c.String(),
                        Account_AccountID = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Account", t => t.Account_AccountID)
                .Index(t => t.Account_AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "Account_AccountID", "dbo.Account");
            DropIndex("dbo.Transaction", new[] { "Account_AccountID" });
            DropTable("dbo.Transaction");
            DropTable("dbo.Account");
        }
    }
}
