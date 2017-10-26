using JB.Production.Infra.Utility.Logger;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JB.Sample.MvcSiteMap.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            #region 多國語系設定
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            CultureInfo ci = null;

            try
            {
                if (cultureCookie != null)  //已設定Culture Cookie，則以Cookie為主
                {
                    ci = new CultureInfo(cultureCookie.Value);
                }
                else //未設定Culture Cookie，以HttpRequest的資訊為主
                {
                    //取得用戶端語言喜好設定(已排序的字串陣列)
                    var userLanguages = Request.UserLanguages;

                    if (userLanguages.Length > 0)
                    {
                        try
                        {
                            ci = new CultureInfo(userLanguages[0]);
                        }
                        catch (CultureNotFoundException)
                        {
                            ci = CultureInfo.InvariantCulture;
                        }
                    }
                    else
                    {
                        ci = CultureInfo.InvariantCulture;
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtility.Logger.Error(ex, "多國語系設定錯誤");
            }
            finally
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            }
            #endregion
        }
    }
}
