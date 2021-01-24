using Dapper;
using SupportTicket.Models;
using SupportTicket.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SupportTicket.Services
{
    public class AgentService
    {
        private readonly AppDbContext db;
        public AgentService()
        {
            db = new AppDbContext();
        }

        public int GetAnAgentId()
        {
            string cString = "Data Source=.;Integrated Security=true;Initial catalog=TicketDb;";

            using (IDbConnection db = new SqlConnection(cString))
            {
                var query = @"select a.Id as AgentId,count(c.Email) as CustomerCount from AppUsers c right join 
                            Agents a on c.AgentId =a.Id 
                            group by a.Id 
                            having Count(a.Id)<4";
                var data = db.Query<AgentData>(query);
                IList<int> availableAgents = new List<int>();
                foreach (var item in data)
                {
                    availableAgents.Add(item.AgentId);
                }
                if (data.Count() == 0)
                {
                    return CreateAgent();
                }
                var randomIndex = new Random().Next(availableAgents.Count);
                return availableAgents[randomIndex];
            }
        }
        private int CreateAgent()
        {
            var agent = new Agent();
            db.Agents.Add(agent);
            db.SaveChanges();
            agent.Name = $"Agent {agent.Id}";
            db.Entry(agent).State = EntityState.Modified;
            db.SaveChanges();
            return agent.Id;
        }
    }
}