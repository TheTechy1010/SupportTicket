using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupportTicket.Models
{
    public class AppUserViewModel
    {
        public AppUserViewModel()
        {
            UserType = UserType.Admin;
        }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public UserType UserType { get; set; }

        public IEnumerable<SelectListItem> UserTypeList
        {
            get
            {
                var list = new List<SelectListItem>();
                var item1 = new SelectListItem();
                item1.Value = UserType.Admin.ToString();
                item1.Text = UserType.Admin.ToString();
                var item2 = new SelectListItem();
                item2.Value = UserType.Customer.ToString();
                item2.Text = UserType.Customer.ToString();
                item2.Selected = true;
                list.Add(item1);
                list.Add(item2);
                return list;
            }
        }
    }
}