using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticketManager.Models;
using DataLibrary;
using static DataLibrary.logic.ticketProcessor;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ticketManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Massage = "Ticket List";
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
                    addBy = !isManagerUser() ? "1" : row.addBy
            }); 
            }
           

                if (!isManagerUser())
                {
                
                    return View(tickets);
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

        public ActionResult NewTicket()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewTicket(Ticket ticket)
        {
            string getUserName = User.Identity.GetUserName();
            
            if (ModelState.IsValid)
            {
                int rec = createTicket(Convert.ToString(ticket.Title), Convert.ToString(ticket.Description)
                    , 0, getUserName);
                //employeeProcessor.createEmployee(employee.userName, employee.fullName, employee.empType = 1);
                return RedirectToAction("Index");
            }
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


    }
}