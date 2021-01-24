namespace SupportTicket.Migrations
{
    using SupportTicket.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SupportTicket.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SupportTicket.Models.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //IList<AppUser> users = new List<AppUser>();
            //var adminUser = new AppUser
            //{
            //    Email = "admin@gmail.com",
            //    UserType = UserType.Admin
            //};
            //context.Set<AppUser>().AddOrUpdate(adminUser);
            //context.SaveChanges();
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
