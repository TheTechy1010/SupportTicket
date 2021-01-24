using SupportTicket.Models;
using SupportTicket.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SupportTicket
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalFilters.Filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Seed Data
            using (var db = new AppDbContext())
            {
                bool isAdminExists = db.Admins.Any(z => z.Email == "admin@gmail.com");
                if (!isAdminExists)
                {
                    var adminuser = new AdminUser
                    {
                        Email = "admin@gmail.com"
                    };
                    db.Admins.Add(adminuser);
                    db.SaveChanges();
                }
                
            }
            

        }
    }
}
