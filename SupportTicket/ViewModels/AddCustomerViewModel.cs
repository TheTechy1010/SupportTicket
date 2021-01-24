using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupportTicket.ViewModels
{
    public class AddCustomerViewModel
    {
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }
    }
}