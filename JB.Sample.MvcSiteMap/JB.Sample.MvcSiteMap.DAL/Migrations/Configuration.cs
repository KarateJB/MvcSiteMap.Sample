#define SeedThisTime

namespace JB.Sample.MvcSiteMap.DAL.Migrations
{
    using Models.DAO;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JB.Sample.MvcSiteMap.DAL.SmDbContext>
    {
        private List<int> adminMenuPermissions = new List<int>(); //系統管理者可使用的Menu
        private List<int> normalUserMenuPermissions = new List<int>(); //一般使用者可使用的Menu

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(JB.Sample.MvcSiteMap.DAL.SmDbContext context)
        {

#if (!SeedThisTime)
            int adminRoleId = 1;
            int normalUserRoleId = 2;


            int movieMenuId = 1;
            int mainRoleMenuId = 2;
            int productMenuId = 3;


            #region SmRole initialize
            this.InitSmRoles(context);
            #endregion

            #region SmMenu initialize
            //Parent Level 
            this.InitParentLevel(context);

            //Level 1 : 電影清單第一層
            this.InitMoviesLevel1(context, movieMenuId);

            //Level 1 : 主要人物第一層
            this.initMainRolesLevel1(context, mainRoleMenuId);

            //Level 1 : 商品第一層
            this.initProductsLevel1(context, productMenuId);
            #endregion

            context.SaveChanges();



            #region SmRoleMenu Initialize
            //Admin <=> Menus
            this.initWahleeRoleMenus(context, adminRoleId, adminMenuPermissions);
            //Normal user <=> Menus
            this.initWahleeRoleMenus(context, normalUserRoleId, normalUserMenuPermissions);

            context.SaveChanges();
            
            #endregion
#endif

#if (SeedThisTime == true)
            /*-----------------------------------------------------------------
            Add the seed functions here!
            -----------------------------------------------------------------*/

            //Do something for seeding here.


#endif
        }

        private void initWahleeRoleMenus(
            SmDbContext context,
            int roleId, List<int> menuIds)
        {
            foreach (int menuId in menuIds)
            {
                context.SmRoleMenus.Add(new SmRoleMenu()
                {
                   SmMenuId = menuId,
                   SmRoleId = roleId
                });
            }
        }
        

        private void initProductsLevel1(
            SmDbContext context, int parentId)
        {
            for (int i = 301; i < (i + 1); i++)
            {
                bool isSubItem = true;

                int smMenuId = i;
                String name = String.Empty;
                String nameCn = String.Empty;
                String nameUs = String.Empty;
                int? orderSn = null;
                String url = String.Empty;
                bool isEnabled = true;

                switch (i)
                {
                    case 301:
                        name = "智慧簡訊機器人";
                        nameCn = "智慧简讯机器人";
                        nameUs = "Smart Sms Robot";
                        orderSn = 1;
                        url = "https://play.google.com/store/apps/details?id=com.jb.Android.JBSMS_GP&hl=zh_HK";
                        break;
                    default:
                        isSubItem = false;
                        break;
                }

                if (isSubItem)
                {
                    context.SmMenus.Add(new SmMenu()
                    {
                        SmMenuId = smMenuId,
                        Name = name,
                        NameCn = nameCn,
                        NameUs = nameUs,
                        OrderSn = orderSn,
                        ParentId = parentId,
                        Url = url,
                        IsEnabled = isEnabled
                    });


                    adminMenuPermissions.Add(smMenuId);
                    normalUserMenuPermissions.Add(smMenuId);
                }
                else //Won't add the item and go for the next item.
                    isSubItem = true;
            }
        }

        private void initMainRolesLevel1(
            SmDbContext context, int parentId)
        {
            for (int i = 201; i < (i + 7); i++)
            {
                bool isSubItem = true;

                int smMenuId = i;
                String name = String.Empty;
                String nameCn = String.Empty;
                String nameUs = String.Empty;
                int? orderSn = null;
                String area = "MainRole";
                String controller = String.Empty;
                String action = String.Empty;
                bool isEnabled = true;

                switch (i)
                {
                    case 201:
                        name = "路克天行者";
                        nameCn = "路克天行者";
                        nameUs = "Luke Skywalker";
                        orderSn = 1;
                        controller = "Jedi";
                        action = "LukeSkywalker";
                        break;
                    case 202:
                        name = "安納金天行者";
                        nameCn = "安纳金天行者";
                        nameUs = "Anakin Skywalker";
                        orderSn = 2;
                        controller = "Jedi";
                        action = "AnakinSkywalker";
                        break;
                    case 203:
                        name = "莉亞天行者";
                        nameCn = "莉亚天行者";
                        nameUs = "Leia Skywalker";
                        orderSn = 3;
                        controller = "Jedi";
                        action = "LeiaSkywalker";
                        break;
                    case 204:
                        name = "尤達";
                        nameCn = "尤达";
                        nameUs = "Yoda";
                        orderSn = 4;
                        controller = "Jedi";
                        action = "Yoda";
                        break;
                    case 205:
                        name = "達斯維達";
                        nameCn = "达斯维达";
                        nameUs = "Darth Vader";
                        orderSn = 5;
                        controller = "Sith";
                        action = "DarthVader";
                        break;
                    case 206:
                        name = "白卜庭";
                        nameCn = "白卜庭";
                        nameUs = "Palpatine";
                        orderSn = 5;
                        controller = "Sith";
                        action = "Palpatine";
                        break;
                    case 207:
                        name = "韓索羅";
                        nameCn = "韩索罗";
                        nameUs = "Han Solo";
                        orderSn = 5;
                        controller = "Other";
                        action = "HanSolo";
                        break;
                    default:
                        isSubItem = false;
                        break;
                }

                if (isSubItem)
                {
                    context.SmMenus.Add(new SmMenu()
                    {
                        SmMenuId = smMenuId,
                        Name = name,
                        NameCn = nameCn,
                        NameUs = nameUs,
                        OrderSn = orderSn,
                        ParentId = parentId,
                        Area = area,
                        Controller = controller,
                        Action = action,
                        IsEnabled = isEnabled
                    });


                    adminMenuPermissions.Add(smMenuId);
                    normalUserMenuPermissions.Add(smMenuId);
                }
                else //Won't add the item and go for the next item.
                    isSubItem = true;
            }
        }

        private void InitMoviesLevel1(
            SmDbContext context,int parentId)
        {
            for (int i = 101; i < (i + 7); i++)
            {
                bool isSubItem = true;

                int smMenuId = i;
                String name = String.Empty;
                String nameCn = String.Empty;
                String nameUs = String.Empty;
                int? orderSn = null;
                String area = "";
                String controller = "Home";
                String action = "Index";
                bool isEnabled = true;

                switch (i)
                {
                    case 101:
                        name = "星際大戰(一)";
                        nameCn = "星际大战（一）";
                        nameUs = "Star Wars I";
                        orderSn = 1;
                        break;
                    case 102:
                        name = "星際大戰(二)";
                        nameCn = "星际大战（二）";
                        nameUs = "Star Wars II";
                        orderSn = 1;
                        break;
                    case 103:
                        name = "星際大戰(三)";
                        nameCn = "星际大战（三）";
                        nameUs = "Star Wars III";
                        orderSn = 1;
                        break;
                    case 104:
                        name = "星際大戰(四)";
                        nameCn = "星际大战（四）";
                        nameUs = "Star Wars IV";
                        orderSn = 1;
                        break;
                    case 105:
                        name = "星際大戰(五)";
                        nameCn = "星际大战（五）";
                        nameUs = "Star Wars V";
                        orderSn = 1;
                        break;
                    case 106:
                        name = "星際大戰(六)";
                        nameCn = "星际大战（六）";
                        nameUs = "Star Wars VI";
                        orderSn = 1;
                        break;
                    case 107:
                        name = "星際大戰(七)";
                        nameCn = "星际大战（七)";
                        nameUs = "Star Wars VII";
                        orderSn = 1;
                        break;
                    default:
                        isSubItem = false;
                        break;
                }

                if (isSubItem)
                {
                    context.SmMenus.Add(new SmMenu()
                    {
                        SmMenuId = smMenuId,
                        Name = name,
                        NameCn = nameCn,
                        NameUs = nameUs,
                        OrderSn = orderSn,
                        ParentId = parentId,
                        Area = area,
                        Controller = controller,
                        Action = action,
                        IsEnabled = isEnabled
                    });
                    adminMenuPermissions.Add(smMenuId);
                    normalUserMenuPermissions.Add(smMenuId);
                }
                else //Won't add the item and go for the next item.
                    isSubItem = true;
            }
        }

        private void InitParentLevel(SmDbContext context)
        {
            for (int i = 1; i < (i + 3); i++)
            {
                bool isSubItem = true;

                int smMenuId = i;
                String name = String.Empty;
                String nameCn = String.Empty;
                String nameUs = String.Empty;
                int? orderSn = null;
                int? parentId = null;
                String area = "";
                String controller = "Home";
                String action = "Index";
                bool isEnabled = true;

                switch (i)
                {
                    case 1:
                        name = "電影";
                        nameCn = "电影";
                        nameUs = "Movies";
                        orderSn = 1;
                        break;
                    case 2:
                        name = "主要人物";
                        nameCn = "主要人物";
                        nameUs = "Main Roles";
                        orderSn = 2;
                        break;
                    case 3:
                        name = "商品";
                        nameCn = "商品";
                        nameUs = "Products";
                        orderSn = 3;
                        break;
                    default:
                        isSubItem = false;
                        break;
                }

                if (isSubItem)
                {
                    context.SmMenus.Add(new SmMenu()
                    {
                        SmMenuId = smMenuId,
                        Name = name,
                        NameCn = nameCn,
                        NameUs = nameUs,
                        OrderSn = orderSn,
                        ParentId = parentId,
                        Area = area,
                        Controller = controller,
                        Action = action,
                        IsEnabled = isEnabled
                    });
                    adminMenuPermissions.Add(smMenuId);
                    normalUserMenuPermissions.Add(smMenuId);
                }
                else //Won't add the item and go for the next item.
                    isSubItem = true;
            }
        }

        private void InitSmRoles(SmDbContext context)
        {
            context.SmRoles.Add(new SmRole()
            {
                Name = "Admin",
                Description = "系統管理者",
                IsEnabled = true
            });
            context.SmRoles.Add(new SmRole()
            {
                Name = "User",
                Description = "一般使用者",
                IsEnabled = true
            });
        }
    }
}