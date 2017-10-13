using System.Web.Mvc;

namespace classdemotoday.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Administration_default2",
                "Administration/{controller}/{action}/{id}",
                new { action = "PendingActivateShopUpdate", id = UrlParameter.Optional }
            );
        }
    }
}