using SupportTicket.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SupportTicket.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("name=conn")
        {
            //Database.SetInitializer(new DbInitializer());
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AdminUser> Admins { get; set; }


    }
}