using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupportTicket.Models
{
    //Admin User Table
    public class AppUser
    {
        public AppUser()
        {
            UserType = UserType.Customer;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }
        public UserType UserType { get; set; }
    }
}