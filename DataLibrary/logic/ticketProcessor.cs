using DataLibrary.dataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.logic
{
    public static class ticketProcessor
    {
        public static int createTicket(string title, string description,
            int status, string addBy)
        {
            TicketModel data = new TicketModel
            {
                Title = title,
                Description = description,
                Status = 0,
                addBy = addBy
            };
            string sql = @"insert into dbo.Ticket (title, description, status, addBy)
                            values (@Title, @Description, @Status, @addBy);";
            return sqlDataAccess.SaveData(sql, data);
        }

        public static List<TicketModel> LoadTickets()
        {
            string sql = @"select Id, title, description, status, addBy from dbo.Ticket;";
            return sqlDataAccess.LoadData<TicketModel>(sql);
        }
        public static int RejectTicket(int id)
        {
            string sql = @"update dbo.Ticket set status=2 where Id =" + id + ";";
            return sqlDataAccess.ExecuteSql<TicketModel>(sql);
        }
        public static int ApproveTicket(int id)
        {
            string sql = @"update dbo.Ticket set status=1 where Id =" + id + ";";
            return sqlDataAccess.ExecuteSql<TicketModel>(sql);
        }
    }
}
