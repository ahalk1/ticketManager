using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ticketManager.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string addBy { get; set; }

    }
}