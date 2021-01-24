using SupportTicket.Models;
using SupportTicket.ViewModels;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Web.Security;

namespace SupportTicket.Controllers
{
    [Authorize]

    public class UserController : Controller
    {
        private readonly AppDbContext db;

        public UserController()
        {
            this.db = new AppDbContext();
        }

        [HttpGet]
        public ActionResult Details()
        {
            var email = User.Identity.Name;
            var customer = db.AppUsers.Include(x => x.Agent).SingleOrDefault(x => x.Email == email);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpGet]
        public ActionResult Exit()
        {
            var email = User.Identity.Name;
            var customer = db.AppUsers.SingleOrDefault(x => x.Email == email);
            if (customer == null)
            {
                return HttpNotFound();
            }
            db.AppUsers.Remove(customer);
            db.SaveChanges();
            FormsAuthentication.SignOut();
            return RedirectToActionPermanent("Index","Home");
            
        }
    }
}