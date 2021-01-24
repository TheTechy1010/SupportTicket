using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportTicket.Models
{
    public enum UserType
    {
        Admin,Customer
    }
    public class Roles
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
    }
}