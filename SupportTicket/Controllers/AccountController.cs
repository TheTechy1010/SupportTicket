using Dapper;
using SupportTicket.Models;
using SupportTicket.Services;
using SupportTicket.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SupportTicket.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly AppDbContext db;
        private readonly AgentService agentService;
        public AccountController()
        {
            this.db = new AppDbContext();
            agentService = new AgentService();
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login() => View(new AppUserViewModel());

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isAdmin = db.Admins.Any(x => x.Email == model.Email && x.UserType == model.UserType);
                if (isAdmin)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToActionPermanent("Index", "Admin");
                }
                else
                {
                    bool isValidUser = db.AppUsers.Any(x => x.Email == model.Email && x.UserType == model.UserType);
                    if (isValidUser)
                    {
                        var userId = (await db.AppUsers.SingleOrDefaultAsync(x => x.Email == model.Email)).Id;
                        FormsAuthentication.SetAuthCookie(model.Email, false);
                        return RedirectToActionPermanent("Details", "User");
                    }
                    else if(db.AppUsers.Any(x => x.Email == model.Email) && model.UserType == UserType.Admin)
                    {
                        ModelState.AddModelError("Unable to login ad admin", "You are not an admin.");
                        return View(new AppUserViewModel());
                    }
                    else if (!isValidUser)
                    {
                        var user = new AppUser
                        {
                            Email = model.Email,
                            AgentId = agentService.GetAnAgentId(),
                            UserType = UserType.Customer
                        };
                        db.AppUsers.Add(user);
                        await db.SaveChangesAsync();
                        FormsAuthentication.SetAuthCookie(user.Email, false);
                        return RedirectToActionPermanent("Details", "User");
                    }
                    
                }
            }
            var vm = new AppUserViewModel();
            ModelState.AddModelError("Unable to login", "Check your Email");
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToActionPermanent("Index", "Home");
        }


    }
}