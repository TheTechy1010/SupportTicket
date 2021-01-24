using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportTicket.ViewModels
{
    public class Assignment
    {
        public Assignment()
        {
            Customers = new Dictionary<int, string>();
        }
        public string AgentName { get; set; }
        public IDictionary<int,string> Customers { get; set; }
    }
}