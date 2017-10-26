using JB.Production.Infra.Utility.Logger;
using JB.Production.Infra.Utility.Utility;
using JB.Sample.MvcSiteMap.DAL;
using JB.Sample.MvcSiteMap.DAL.Models.DAO;
using JB.Sample.MvcSiteMap.DAL.Service;
using JB.Sample.MvcSiteMap.Domain.Models.Enum;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace JB.Sample.MvcSiteMap.Website.Utility.SiteMap
{
    public class MenuNodeProvider : DynamicNodeProviderBase
    {
        public MenuNodeProvider() : base()
        {

        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();
            CultureEnum cultureEnum = this.getCurrentCulture();

            try
            {

                using (var menuService = new SmMenuService<SmMenu>(new SmDbContext()))
                using (var roleMenuService = new SmRoleMenuService<SmRoleMenu>(new SmDbContext()))
                {
                    // 取出所有Menu項
                    var menus = menuService.GetAll().ToList();

                    //LogUtility.Logger.Debug($"The number of menus are {roleMenus.Count()}");
                    foreach (var menu in menus)
                    {
                        //取出該Menu對應那些Roles
                        IList<String> roles = roleMenuService.Get(x => x.SmMenuId == menu.SmMenuId).ToList().Select(x => x.SmRole.Name).ToList();


                        DynamicNode dynamicNode = new DynamicNode()
                        {
                            // 顯示的文字
                            //Title = menu.Name,
                            Title = this.getLocalizeTitle(menu, cultureEnum),
                            // 父Menu項目Id
                            ParentKey = menu.ParentId.HasValue ? menu.ParentId.Value.ToString() : "",
                            // Node key
                            Key = menu.SmMenuId.ToString(),
                            // Action name
                            Action = menu.Action,
                            // Controller name
                            Controller = menu.Controller,
                            // Area name
                            Area = menu.Area,
                            // Url (只要有值就會以此為主)
                            Url = menu.Url,
                            // Roles
                            Roles = roles
                        };

                        if (!string.IsNullOrWhiteSpace(menu.RouteValues))
                        {
                            var keyVals =
                                Serializer.FromJson<List<KeyValuePair<String, String>>>(menu.RouteValues);
                            dynamicNode.RouteValues = keyVals.ToDictionary(x => x.Key, x => (object)x.Value);
                        }

                        returnValue.Add(dynamicNode);
                    }
                }


                LogUtility.Logger.Debug($"Node數量 = {returnValue.Count}!");

                return returnValue;
            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, ex.Message);
                return null;
            }

        }

        private string getLocalizeTitle(SmMenu menu, CultureEnum cultureEnum)
        {
            if (cultureEnum.Equals(CultureEnum.zhTW))
            {
                return menu.Name;
            }
            else if (cultureEnum.Equals(CultureEnum.zhCN))
            {
                return menu.NameCn;
            }
            else
                return menu.NameUs;
        }

        private CultureEnum getCurrentCulture()
        {
            CultureEnum cultureEnum = CultureEnum.enUS; //default : en-US
            CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (ci != null)
            {
                switch (ci.Name.ToLower())
                {
                    case "zh-tw":
                        cultureEnum = CultureEnum.zhTW;
                        break;
                    case "zh-cn":
                        cultureEnum = CultureEnum.zhCN;
                        break;
                    default: //Default : en-US
                        cultureEnum = CultureEnum.enUS;
                        break;
                }
            }

            return cultureEnum;
        }
    }
}