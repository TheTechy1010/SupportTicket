using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SupportTicket.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            //IList<AppUser> users = new List<AppUser>();
            //var adminUser = new AppUser
            //{
            //    Email = "admin@gmail.com",
            //    UserType = UserType.Admin
            //};
            //var normalUser = new AppUser
            //{
            //    Email = "user@gmail.com",
            //    UserType = UserType.Customer
            //};
            //users.Add(adminUser);
            //users.Add(normalUser);
            //context.AppUsers.AddRange(users);
            //context.SaveChanges();

        }
    }
}