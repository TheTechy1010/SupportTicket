using SupportTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportTicket.ViewModels
{
    public class AdminUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; } = UserType.Admin;
    }
}