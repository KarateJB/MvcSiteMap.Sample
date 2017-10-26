using System.Web.Mvc;

namespace JB.Sample.MvcSiteMap.Website.Areas.MainRole
{
    public class MainRoleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MainRole";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MainRole_default",
                "MainRole/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}