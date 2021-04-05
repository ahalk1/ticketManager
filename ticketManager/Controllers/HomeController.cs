using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticketManager.Models;
using static ticketManager.Models.ticketProcessor;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Dynamic;

namespace ticketManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            Ticket ticket = new Ticket();
            return View(ticket);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Ticket ticket)
        {
            string getUserName = User.Identity.GetUserName();

            if (ModelState.IsValid)
            {
                int rec = createTicket(Convert.ToString(ticket.Title), Convert.ToString(ticket.Description)
                    , 0, getUserName);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult NewTicket()
        {
            return View();
        }
       



        public ActionResult rejectTicket(int id)
        {
            RejectTicket(id);
            return RedirectToAction("Index");
        }


        public ActionResult approveTicket(int id)
        {
            ApproveTicket(id);
            return RedirectToAction("Index");
        }

        public ViewResult listOfTicket()
        {
            ViewBag.Massage = "Ticket List";
            dynamic mymodel = new ExpandoObject();
            var data = LoadTickets();
            List<Ticket> tickets = new List<Ticket>();

            foreach (var row in data)
            {
                tickets.Add(new Ticket
                {
                    Id = row.Id,
                    Title = row.Title,
                    Description = row.Description,
                    Status = row.Status,
                    addBy =  row.addBy
                });
            }
            return View(tickets);
        }

        public Boolean isManagerUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Manager")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


    }
}