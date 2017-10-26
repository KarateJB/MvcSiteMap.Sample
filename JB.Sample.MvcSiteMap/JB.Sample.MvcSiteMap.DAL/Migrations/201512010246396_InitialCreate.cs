namespace JB.Sample.MvcSiteMap.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SmMenus",
                c => new
                    {
                        SmMenuId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        NameCn = c.String(nullable: false, maxLength: 200),
                        NameUs = c.String(nullable: false, maxLength: 200),
                        Area = c.String(maxLength: 100),
                        Controller = c.String(maxLength: 100),
                        Action = c.String(maxLength: 100),
                        Url = c.String(),
                        Description = c.String(maxLength: 500),
                        ParentId = c.Int(),
                        RouteValues = c.String(),
                        OrderSn = c.Int(),
                        IsEnabled = c.Boolean(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        UpdateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SmMenuId);
            
            CreateTable(
                "dbo.SmRoleMenus",
                c => new
                    {
                        SmRoleId = c.Int(nullable: false),
                        SmMenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SmRoleId, t.SmMenuId })
                .ForeignKey("dbo.SmMenus", t => t.SmMenuId, cascadeDelete: true)
                .ForeignKey("dbo.SmRoles", t => t.SmRoleId, cascadeDelete: true)
                .Index(t => t.SmRoleId)
                .Index(t => t.SmMenuId);
            
            CreateTable(
                "dbo.SmRoles",
                c => new
                    {
                        SmRoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        Description = c.String(maxLength: 500),
                        IsEnabled = c.Boolean(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        UpdateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SmRoleId);
            
            CreateTable(
                "dbo.SmUserRoles",
                c => new
                    {
                        SmUserId = c.String(nullable: false, maxLength: 300),
                        SmRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SmUserId, t.SmRoleId })
                .ForeignKey("dbo.SmRoles", t => t.SmRoleId, cascadeDelete: true)
                .ForeignKey("dbo.SmUsers", t => t.SmUserId, cascadeDelete: true)
                .Index(t => t.SmUserId)
                .Index(t => t.SmRoleId);
            
            CreateTable(
                "dbo.SmUsers",
                c => new
                    {
                        SmUserId = c.String(nullable: false, maxLength: 300),
                        Name = c.String(nullable: false, maxLength: 200),
                        AdUserId = c.String(nullable: false, maxLength: 300),
                        IsEnabled = c.Boolean(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        UpdateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SmUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SmUserRoles", "SmUserId", "dbo.SmUsers");
            DropForeignKey("dbo.SmUserRoles", "SmRoleId", "dbo.SmRoles");
            DropForeignKey("dbo.SmRoleMenus", "SmRoleId", "dbo.SmRoles");
            DropForeignKey("dbo.SmRoleMenus", "SmMenuId", "dbo.SmMenus");
            DropIndex("dbo.SmUserRoles", new[] { "SmRoleId" });
            DropIndex("dbo.SmUserRoles", new[] { "SmUserId" });
            DropIndex("dbo.SmRoleMenus", new[] { "SmMenuId" });
            DropIndex("dbo.SmRoleMenus", new[] { "SmRoleId" });
            DropTable("dbo.SmUsers");
            DropTable("dbo.SmUserRoles");
            DropTable("dbo.SmRoles");
            DropTable("dbo.SmRoleMenus");
            DropTable("dbo.SmMenus");
        }
    }
}
