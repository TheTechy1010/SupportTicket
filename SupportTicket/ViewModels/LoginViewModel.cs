using SupportTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportTicket.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public bool RememberMe { get; set; }
    }
}