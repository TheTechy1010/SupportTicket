using SupportTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using SupportTicket.ViewModels;

namespace SupportTicket.Controllers
{
    [Authorize(Roles =Roles.Admin)]
    public class AdminController : Controller
    {
        private readonly AppDbContext db;

        public AdminController()
        {
            this.db = new AppDbContext();
        }

        // GET: Admin
        public ActionResult Index()
        {
            var allAssignments = db.AppUsers.Include(c => c.Agent).ToList();
            var groupedResult = allAssignments.GroupBy(x => x.AgentId);
            var assignments = new List<Assignment>();
            foreach (var item in groupedResult)
            {
                var assignData = new Assignment();
                assignData.AgentName = $"Agent {item.Key}";
                foreach (var cust in item)
                {
                    assignData.Customers.Add(cust.Id, cust.Email);
                }
                assignments.Add(assignData);
            }
            return View(assignments);
        }
    }
}