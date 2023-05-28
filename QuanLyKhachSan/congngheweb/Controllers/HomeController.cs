using congngheweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace congngheweb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Room()
        {
            
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _Contact(FormCollection form)
        {
            var fullname = form["name"];
            var email = form["email"];
            var message = form["message"];
            DB db = new DB();
            DateTime currentTime = DateTime.Now;
            comment comment = new comment
            {
                email = email,
                fullname = fullname,
                message = message,
                created_at = currentTime,
            };

            db.comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Contact");
        }



        [HttpPost]
        public ActionResult booking(FormCollection form)
        {
            string fullname = form["fullname"];
            string email = form["email"];
            string phonenumber = form["phone"];
            int guest = Convert.ToInt32(form["guest"]);
            int room = Convert.ToInt32(form["room"]);

            DateTime checkin = Convert.ToDateTime(form["checkin"]);
            DateTime checkout = Convert.ToDateTime(form["checkout"]);


            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var code = new string(Enumerable.Repeat(chars, 20)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            DateTime currentTime = DateTime.Now;
            DB db = new DB();
            booking bk = new booking
            {
                code = code,
                fullname = fullname,
                email = email,
                phonenumber = phonenumber,
                guest = guest,
                checkin = checkin,
                checkout = checkout,
                room = room,
                status = 0,
                created_at = currentTime,
                updated_at = currentTime,

            };

            db.bookings.Add(bk);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}