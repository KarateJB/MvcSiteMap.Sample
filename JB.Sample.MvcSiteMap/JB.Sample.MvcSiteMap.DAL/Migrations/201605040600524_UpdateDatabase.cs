namespace JB.Sample.MvcSiteMap.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CcRoleMenus", "CcMenuId", "dbo.CcMenus");
            DropForeignKey("dbo.CcRoleMenus", "SmRoleId", "dbo.SmRoles");
            DropIndex("dbo.CcRoleMenus", new[] { "SmRoleId" });
            DropIndex("dbo.CcRoleMenus", new[] { "CcMenuId" });
            DropTable("dbo.CcMenus");
            DropTable("dbo.CcRoleMenus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SmRoleMenus",
                c => new
                    {
                        SmRoleId = c.Int(nullable: false),
                        SmMenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SmRoleId, t.SmMenuId });
            
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
            
            CreateIndex("dbo.SmRoleMenus", "SmMenuId");
            CreateIndex("dbo.SmRoleMenus", "SmRoleId");
            AddForeignKey("dbo.SmRoleMenus", "SmRoleId", "dbo.SmRoles", "SmRoleId", cascadeDelete: true);
            AddForeignKey("dbo.SmRoleMenus", "SmMenuId", "dbo.SmMenus", "SmMenuId", cascadeDelete: true);
        }
    }
}
