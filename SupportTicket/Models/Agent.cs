using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupportTicket.Models
{
    public class Agent
    {
        public Agent()
        {
            Name = $"Agent {Id}";
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }
    }
}